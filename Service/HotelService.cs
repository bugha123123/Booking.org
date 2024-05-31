using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using static Hotel.org.Models.Hotels;

namespace Hotel.org.Service
{
    public class HotelService : IHotelService
    {

        private readonly AppDbContext _appDbContext;
        private readonly IAccountService _accountService;
        private int MIN_PRICE = 950;
        public HotelService(AppDbContext appDbContext, IAccountService accountService)
        {
            _appDbContext = appDbContext;
            _accountService = accountService;
        }


        //books hotel for user
        public async Task BookHotel(int hotelId, string cardNumber, string cvc)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var foundHotel = await GetHotelById(hotelId);

            // Check if the user has already booked this hotel
            var existingBooking = await _appDbContext.bookedHotels
                .FirstOrDefaultAsync(b => b.AddedBy == user.Email && b.HotelId == foundHotel.Id);

            // If the user has already booked this hotel, return without booking again
            if (existingBooking != null)
            {
                // You can handle this case as needed, such as throwing an exception or logging a message
                return;
            }

            // Validate payment details
            bool isValidPayment = await ValidatePaymentDetailsAsync(user, cardNumber, cvc);
            if (!isValidPayment)
            {
                throw new ArgumentException("Invalid payment details.");
            }

            // Store the original price
            var originalPrice = foundHotel.AveragePricePerNight;

            // Calculate the discount based on the user's tier level
            decimal discount = 0m;
            if (await IsFirstTimeBooking(user))
            {
                switch (user.tierLevels)
                {
                    case User.TierLevels.SILVER:
                        discount = 5;
                        user.Points += 2;
                        break;
                    case User.TierLevels.GOLD:
                        discount = 10;
                        user.Points += 3;
                        break;
                    case User.TierLevels.PLATINUM:
                        discount = 15;
                        user.Points += 4;
                        break;
                    case User.TierLevels.Member:
                        discount = 2;
                        user.Points += 1;
                        break;
                    default:    
                        discount = 0;
                        user.Points += (int).5;
                        break;
                }
            }

            // Apply the discount
            foundHotel.AveragePricePerNight -= discount;

            // Create a new booked hotel entry
            var bookedHotel = new BookedHotels()
            {
                AddedBy = user.UserName,
                HotelId = foundHotel.Id,
                hotel = foundHotel,
                BookedHotelImage = foundHotel.RoomImage,
                user = user,
                UserId = user.Id,
                // Set the booking price to the discounted price
                
            };

            user.Points += 1;

            // Update the user's tier level based on points
            if (user.Points >= 5.5)
            {
                user.tierLevels = User.TierLevels.PLATINUM;
            }
            else if (user.Points >= 1.5)
            {
                user.tierLevels = User.TierLevels.GOLD;
            }

            await _appDbContext.bookedHotels.AddAsync(bookedHotel);
            await _appDbContext.SaveChangesAsync();

            // Reset the hotel's price to its original value
            foundHotel.AveragePricePerNight = originalPrice;
            await _appDbContext.SaveChangesAsync();

            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("irakliberdzena314@gmail.com", "coca mmba ywsy lvyz ");

                using (var message = new MailMessage(
                    from: new MailAddress("irakliberdzena314@gmail.com", "tryhardgamer"),
                    to: new MailAddress(user.Email, user.UserName)
                ))
                {
                    message.Subject = "Payment Receipt - Hotel Booking Service";
                    message.IsBodyHtml = true; // Ensure that the body is treated as HTML

                    // Create the HTML view
                    string htmlBody = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f6f6f6;
                            padding: 20px;
                        }}
                        .receipt-container {{
                            background-color: #ffffff;
                            padding: 20px;
                            border-radius: 10px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                            max-width: 600px;
                            margin: 0 auto;
                        }}
                        .receipt-header {{
                            font-size: 24px;
                            font-weight: bold;
                            color: #333333;
                        }}
                        .receipt-table {{
                            width: 100%;
                            margin: 20px 0;
                            border-collapse: collapse;
                        }}
                        .receipt-table td {{
                            padding: 10px;
                            border-bottom: 1px solid #dddddd;
                        }}
                        .receipt-table td:first-child {{
                            font-weight: bold;
                            color: #555555;
                        }}
                        .receipt-footer {{
                            margin-top: 20px;
                            font-size: 14px;
                            color: #777777;
                        }}
                        .receipt-footer a {{
                            color: #007bff;
                            text-decoration: none;
                        }}
                        .receipt-footer a:hover {{
                            text-decoration: underline;
                        }}
                    </style>
                </head>
                <body>
                    <div class='receipt-container'>
                        <p class='receipt-header'>Payment Receipt</p>
                        <p>Dear {user.UserName},</p>
                        <p>Thank you for your payment!</p>
                        <p>Here are your payment details:</p>
                        <table class='receipt-table'>
                            <tr><td>Hotel Name:</td><td>{foundHotel.Name}</td></tr>
                            <tr><td>Amount Paid:</td><td>${foundHotel.AveragePricePerNight:F2}</td></tr>
                            <tr><td>Payment Date:</td><td>{DateTime.UtcNow:yyyy-MM-dd}</td></tr>
                        </table>
                        <p>We are looking forward to hosting you. If you have any questions or need further assistance, please don't hesitate to contact us.</p>
                        <p class='receipt-footer'>
                            Best regards,<br>
                            Booking Service Team<br>
                            <a href='https://localhost:7206/Hotel/ViewReservationPage?HotelId={foundHotel.Id}'>Click here to view your reservation</a>
                        </p>
                    </div>
                </body>
                </html>";

                    message.Body = htmlBody;

                    // Send the email
                    client.Send(message);
                }
            }
        }


        public async Task<bool> ValidatePaymentDetailsAsync(User user, string cardNumber, string cvc)
        {
            // Check if the provided card number and cvc match the user's stored values
            return user.CardNumber.Trim() == cardNumber && user.CardCV.Trim() == cvc;
        }


        public async Task<bool> IsFirstTimeBooking(User user)
        {
            return !await _appDbContext.bookedHotels.AnyAsync(x => x.UserId == user.Id);
        }


        public Task<Hotels> GetHotelById(int id)
        {
            var hotel = _appDbContext.Hotels.FirstOrDefaultAsync(h => h.Id == id);
            return hotel;
        }
        public async Task<bool> IsHotelBookedAsync(int hotelId)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var foundHotel = await GetHotelById(hotelId);
            if (user == null)
            {
                return false; // User not logged in, so the hotel is not booked
            }

            return await _appDbContext.bookedHotels.AnyAsync(b => b.AddedBy == user.UserName && b.HotelId == foundHotel.Id);
        }


        //takes 8 hotels and returns them 
        public async Task<List<Hotels>> GetHotelsAsync()
        {
        return    await _appDbContext.Hotels.Include(u => u.user).Take(10).ToListAsync(); 
        }

        //searches for hotel using query
        public async Task<List<Hotels>> SearchForHotel(string? place, string? checkInTime, string? checkOutTime, string? adultsCount, string? childrenCount)
        {
            var query = _appDbContext.Hotels.AsQueryable();

            // Filter by place
            if (!string.IsNullOrEmpty(place))
            {
                query = query.Where(hotel => hotel.City.ToLower().Contains(place.ToLower()));
            }

            // Filter by number of adults
            if (!string.IsNullOrEmpty(adultsCount) && Enum.TryParse(adultsCount, out NumberOfAdultsEnum adults))
            {
                query = query.Where(hotel => hotel.NumberOfAdults == adults);
            }

            // Filter by number of children
            if (!string.IsNullOrEmpty(childrenCount) && Enum.TryParse(childrenCount, out NumberOfChildrenEnum children))
            {
                query = query.Where(hotel => hotel.NumberOfChildren == children);
            }

            // Filter by check-in and check-out times
            if (!string.IsNullOrEmpty(checkInTime) && TimeSpan.TryParse(checkInTime, out TimeSpan checkIn) &&
                !string.IsNullOrEmpty(checkOutTime) && TimeSpan.TryParse(checkOutTime, out TimeSpan checkOut))
            {
                // Filter hotels where the stay period overlaps with the specified range
                query = query.Where(hotel => !(hotel.CheckOutTime <= checkIn || hotel.CheckInTime >= checkOut));
            }

            // Execute the query and return the filtered hotels
            return await query.ToListAsync();
        }


        //gets booked hotels by id and checks if that booked hotel is for logged in  user or not
        public async Task<BookedHotels> GetBookedHotelById(int BookedHotelId)
        {
            // Retrieve the logged-in user
            var user = await _accountService.GetLoggedInUserAsync();
            var bookedhotel = await _appDbContext.bookedHotels.Include(x => x.hotel).FirstOrDefaultAsync(x => x.HotelId == BookedHotelId);
            // If user is null, handle the case appropriately (e.g., return null or throw an exception)
            if (user == null)
            {
                throw new InvalidOperationException("Unable to retrieve logged in user.");
            }

            // Query the database for the booked hotel matching the hotelId and added by the logged-in user
            var foundBookedHotel = await _appDbContext.bookedHotels.FirstOrDefaultAsync(bh => bh.Id == bookedhotel.Id);

            // If no booked hotel is found, return null
            if (foundBookedHotel == null)
            {
                return null;
            }

            // Return the found booked hotel
            return foundBookedHotel;
        }
        

        //gets booked hotels for user that is logged in and shows them on ReservationsPage
        public async Task<List<BookedHotels>> GetAllBookedHotelsAsync()
        {
            var user = await _accountService.GetLoggedInUserAsync();
             var FoundBookedHotels = await _appDbContext.bookedHotels.Include(x => x.hotel).Where(bh => bh.AddedBy == user.Email).ToListAsync();

            return FoundBookedHotels;
        }

        public async Task<List<Hotels>> GetAllHotelsForDropDown()
        {
            var hotels = await _appDbContext.Hotels.ToListAsync();
            return hotels;
        }

        public async Task CancelReservation(int BookedHotelId)
        {
            try
            {
                var user = await _accountService.GetLoggedInUserAsync();
                var foundBookedHotel = await GetBookedHotelByIdUsedForReservationCanceling(BookedHotelId);

                if (foundBookedHotel == null)
                {
                    // Log or handle the case where the booked hotel is not found
                    return;
                }
                user.Points -= 1;
                _appDbContext.bookedHotels.Remove(foundBookedHotel);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception
            }
        }

        public async Task<BookedHotels> GetBookedHotelByIdUsedForReservationCanceling(int BookedHotelId)
        {
            // Retrieve the logged-in user
            var user = await _accountService.GetLoggedInUserAsync();

            // Retrieve the booked hotel based on the ID
            var bookedHotel = await _appDbContext.bookedHotels.Include(x => x.hotel).FirstOrDefaultAsync(bh => bh.Id == BookedHotelId);

            return bookedHotel;
        }


        //filters hotel on search page

        public async Task<List<Hotels>> GetFilteredHotelsByPrice(decimal? minPrice, decimal? maxPrice, bool? hasGym, bool? hasPool, bool? hasBreakfast, int rating, int numberOfRooms)
        {
            IQueryable<Hotels> query = _appDbContext.Hotels.AsQueryable();

            // Filter hotels by price range if provided
            if (minPrice != null && maxPrice != null)
            {
                query = query.Where(h => h.AveragePricePerNight >= minPrice && h.AveragePricePerNight <= maxPrice);
            }

            // Filter hotels by amenities if provided
            if (hasGym != null)
            {
                query = query.Where(h => h.Gym == hasGym);
            }
            if (hasPool != null)
            {
                query = query.Where(h => h.Pool == hasPool);
            }
            if (hasBreakfast != null)
            {
                query = query.Where(h => h.Breakfast == hasBreakfast);
            }

            // Filter hotels by rating if provided
            if (rating != 0)
            {
                query = query.Where(h => h.Rating == rating);
            }

            // Filter hotels by number of rooms if provided
            if (numberOfRooms != 0)
            {
                query = query.Where(h => h.NumberOfRooms == numberOfRooms);
            }

            return await query.ToListAsync();
        }




        // adds review for hotel 
        public async Task AddReviewForHotel(Reviews reviews)
        {
            var user = await _accountService.GetLoggedInUserAsync();

            var NewReview = new Reviews()
            {
                AddedBy = user.UserName,
                Comment = reviews.Comment,
                Stars = reviews.Stars,
                AddedForHotel = reviews.AddedForHotel,
                user = user,
                UserId = user.Id,
               Type = Reviews.ReviewType.Hotel,
               
                


            };


            await _appDbContext.reviews.AddAsync(NewReview);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<Reviews>> GetReviewsForHotelAsync(int HotelId)
        {
            var FoundeHotel = await GetHotelById(HotelId);

            var foundReviews = await _appDbContext.reviews.Include(u => u.user).Where(r => r.AddedForHotel == FoundeHotel.Name).ToListAsync();

            return foundReviews;

        }

        public async Task<List<Hotels>> GetHotelsByRating()
        {
           return await _appDbContext.Hotels.Where(x => x.Rating >= 4).ToListAsync();
        }

        public async Task AddHotelToFavourites(int HotelId)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var FoundHotel = await GetHotelById(HotelId);
            if (user != null && FoundHotel != null )
            {

                if (await IsHotelAlreadyFavouritedByUser(user,FoundHotel))
                {
                    throw new Exception("hotel already booked.");
                }
                var FavaouritedHotel = new Favourites()
                {
                    FavoutiredHotelName = FoundHotel.Name,
                    hotel = FoundHotel,
                    HotelId = FoundHotel.Id,
                    user = user,
                    UserId = user.Id


                };

                await _appDbContext.Favourites.AddAsync(FavaouritedHotel);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<bool> IsHotelAlreadyFavouritedByUser(User user, Hotels hotel)
        {
            if (user == null || hotel == null)
            {
                // Handle the case where either user or hotel is null
                return false;
            }

            var ExistingFavouritedHotel = await _appDbContext.Favourites
                .Include(fh => fh.user)
                .FirstOrDefaultAsync(fh => fh.user.Email == user.Email && fh.hotel.Name == hotel.Name);

            if (ExistingFavouritedHotel == null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Favourites>> GetFavouriteHotelsForUser()
        {
            var user = await _accountService.GetLoggedInUserAsync();

            var favouritedHotel = await _appDbContext.Favourites.Include(x => x.hotel).Include(x => x.user).Where(u => u.UserId == user.Id).ToListAsync();

                return favouritedHotel;
        }

        public async Task RemoveHotelFromFavourites(int HotelId)
        {
            var foundHotel =await  GetHotelById(HotelId);
            var user = await _accountService.GetLoggedInUserAsync();
            var HotelToRemove = await _appDbContext.Favourites.FirstOrDefaultAsync(f => f.hotel.Id == foundHotel.Id && f.user.Id == user.Id);

            if (HotelToRemove == null)
            {
                return;
            }

            _appDbContext.Favourites.Remove(HotelToRemove);
          await  _appDbContext.SaveChangesAsync();

        }

        public async Task<List<Hotels>> GetExpensiveHotels()
        {
            var ExpensiveHotels = await _appDbContext.Hotels.Where(h => h.AveragePricePerNight >= MIN_PRICE).ToListAsync();

            return ExpensiveHotels;
        }

        public async Task<List<Flights>> GetFlightsAssociatedToHotel(int HotelId)
        {
            var FoundHotel = await GetBookedHotelById(HotelId);

            return await _appDbContext.Flights.Where(f => f.To == FoundHotel.hotel.Name).ToListAsync();
        }
    }
}
