﻿using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using static Hotel.org.Models.Reviews;

namespace Hotel.org.Service
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAccountService _accountService;
        private readonly IHotelService _hotelService;
        private int MIN_PRICE = 220;
        private double MIN_RATING = 4.5;
        public FlightService(AppDbContext appDbContext, IAccountService accountService, IHotelService hotelService)
        {
            _appDbContext = appDbContext;
            _accountService = accountService;
            _hotelService = hotelService;
        }



        public async Task<List<Flights>> GetAllFlightsForDropDown()
        {
            return await _appDbContext.Flights.Include(x => x.Hotel).ToListAsync();
                
        }

        public async Task<Flights> GetFlightById(int Id)
        {
            return await _appDbContext.Flights.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Flights>> GetFlightsAsync()
        {
            return await _appDbContext.Flights.Include(u => u.Hotel).Include(x => x.User).Take(8).ToListAsync();
        }

        public async Task<List<Flights>> SearchForFlight(string? departureLocation, string? destination, string? departureTime, string? arrivalTime)
        {
            // Parse departure and arrival times
            DateTime? parsedDepartureTime = !string.IsNullOrEmpty(departureTime) ? DateTime.Parse(departureTime) : (DateTime?)null;
            DateTime? parsedArrivalTime = !string.IsNullOrEmpty(arrivalTime) ? DateTime.Parse(arrivalTime) : (DateTime?)null;

            // Query to search for flights
            var query = _appDbContext.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(departureLocation))
            {
                query = query.Where(f => f.From == departureLocation);
            }

            if (!string.IsNullOrEmpty(destination))
            {
                query = query.Where(f => f.To == destination);
            }

            if (parsedDepartureTime.HasValue)
            {
                query = query.Where(f => f.DepartureTime >= parsedDepartureTime.Value);
            }

            if (parsedArrivalTime.HasValue)
            {
                query = query.Where(f => f.ArrivalTime <= parsedArrivalTime.Value);
            }

        

            return await query.ToListAsync();
        }


        public async Task AddReviewForFlight(Reviews reviews)
        {
            var user = await _accountService.GetLoggedInUserAsync();

            var NewReview = new Reviews()
            {
                AddedBy = user.UserName,
                Comment = reviews.Comment,
                Stars = reviews.Stars,
AddedForFlight = reviews.AddedForFlight,
                user = user,
                UserId = user.Id,
                Type = Reviews.ReviewType.Flight,




            };


            await _appDbContext.reviews.AddAsync(NewReview);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<Reviews>> GetReviewsForFlight(int HotelId)
        {
            var FoundeFlight = await GetFlightById(HotelId);

            var foundReviews = await _appDbContext.reviews.Include(u => u.user).Where(r => r.AddedForFlight == FoundeFlight.To).ToListAsync();

            return foundReviews;

        }

        public async Task BookFlight(int FlightId, string cardNumber, string cvc)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var foundFlight = await GetFlightById(FlightId);

            // Check if the user has already booked this flight
            var existingBooking = await _appDbContext.BookedFlights
                .FirstOrDefaultAsync(b => b.user.Email == user.Email && b.FlightId == foundFlight.Id);

            // If the user has already booked this flight, return without booking again
            if (existingBooking != null)
            {
                // You can handle this case as needed, such as throwing an exception or logging a message
                return;
            }

            // Validate payment details
            bool isValidPayment = await _hotelService.ValidatePaymentDetailsAsync(user, cardNumber, cvc);
            if (!isValidPayment)
            {
                throw new ArgumentException("Invalid payment details.");
            }

            // Create a new booked hotel entry
            var bookedFlight = new BookedFlights()
            {
                FlightId = foundFlight.Id,
                Flights = foundFlight,
                user = user,
                UserId = user.Id
            };


            // checks if user has booked any flights or not
            if (await IsFirstTimeBooking(user))
            {
                if (user.tierLevels != User.TierLevels.Member)
                {
                    if (user.tierLevels == User.TierLevels.SILVER)
                    {
                        foundFlight.Price -= 5;
                    }

                    if (user.tierLevels == User.TierLevels.GOLD)
                    {
                        foundFlight.Price -= 10;
                    }

                    if (user.tierLevels == User.TierLevels.PLATINUM)
                    {
                        foundFlight.Price -= 15;
                    }
                }
                else {
                    foundFlight.Price -= 2;
                }


            }

            user.Points += 1;

            if (user.Points >= 1.5)
            {
                user.tierLevels = User.TierLevels.GOLD;

            }

            if (user.Points >= 5.5)
            {
                user.tierLevels = User.TierLevels.PLATINUM;
            }
            await _appDbContext.BookedFlights.AddAsync(bookedFlight);
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
                    message.Subject = "Flight booking service";
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
                            <tr><td>Hotel Name:</td><td>{foundFlight.Airline}</td></tr>
                            <tr><td>Amount Paid:</td><td>${foundFlight.Price:F2}</td></tr>
                            <tr><td>Payment Date:</td><td>{DateTime.UtcNow:yyyy-MM-dd}</td></tr>
                        </table>
                        <p>We are looking forward to hosting you. If you have any questions or need further assistance, please don't hesitate to contact us.</p>
                        <p class='receipt-footer'>
                            Best regards,<br>
                            Booking Service Team<br>
                            <a href='https://localhost:7206/Flight/ViewFlightReservationsPage?FlightId={foundFlight.Id}'>Click here to view your reservation</a>
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

        public async Task<bool> IsFlightBookedAsync(int FlightId)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var foundFlight = await GetFlightById(FlightId);
            if (user == null)
            {
                return false; // User not logged in, so the flight is not booked
            }

            return await _appDbContext.BookedFlights.AnyAsync(b => b.user.Email == user.Email && b.FlightId == foundFlight.Id);
        }
        private async Task<bool> IsFirstTimeBooking(User user)
        {
            return !await _appDbContext.BookedFlights.AnyAsync(x => x.UserId == user.Id);
        }

        public async Task<List<Hotels>> GetHotelsAssociatedToFlight(int FlightId)
        {
            var FoundFlight = await GetFlightById(FlightId);

            return await _appDbContext.Hotels.Where(f => f.Name == FoundFlight.To).ToListAsync(); 
        }


        public async Task AddFlightToFavourites(int FlightId)
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var FoundFlight = await GetFlightById(FlightId);
            if (user != null && FoundFlight != null)
            {

                if (await IsFlightAlreadyFavouritedByUser(user, FoundFlight))
                {
                    throw new Exception("flight already booked.");
                }
                var FavaouritedFlight = new FavouritedFlights()
                {
                    flight = FoundFlight,
                    FlightId = FoundFlight.Id,
                    user = user,
                    UserId = user.Id


                };

                await _appDbContext.FavouritedFlights.AddAsync(FavaouritedFlight);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<bool> IsFlightAlreadyFavouritedByUser(User user, Flights flight)
        {
            if (user == null || flight == null)
            {
                // Handle the case where either user or flight is null
                return false;
            }

            var ExistingFavouritedFlight = await _appDbContext.FavouritedFlights
                .Include(fh => fh.user)
                .FirstOrDefaultAsync(ff => ff.user.Email == user.Email && ff.flight.To == flight.To);

            if (ExistingFavouritedFlight == null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<FavouritedFlights>> GetFavouriteFlightsForUser()
        {
            var user = await _accountService.GetLoggedInUserAsync();

            var favouritedFLight = await _appDbContext.FavouritedFlights.Include(x => x.flight).Include(x => x.user).Where(u => u.UserId == user.Id).ToListAsync();

            return favouritedFLight;
        }

        public async Task RemoveFlightsFromFavourites(int FlightId)
        {
            var foundFlight = await GetFlightById(FlightId);
            var user = await _accountService.GetLoggedInUserAsync();
            var FlightToRemove = await _appDbContext.FavouritedFlights.FirstOrDefaultAsync(f => f.flight.Id == foundFlight.Id && f.user.Id == user.Id);

            if (FlightToRemove == null)
            {
                return;
            }

            _appDbContext.FavouritedFlights.Remove(FlightToRemove);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<BookedFlights>> GetBookedFlights()
        {
            var user = await _accountService.GetLoggedInUserAsync();
            var FoundBookedFlights = await _appDbContext.BookedFlights.Include(x => x.Flights).Where(bh => bh.user.Id == user.Id).ToListAsync();

            return FoundBookedFlights;
        }

        public async Task<List<Flights>> GetTopRatedFlightsAsync()
        {
            return await _appDbContext.Flights.Where(X => X.Price >= MIN_PRICE).ToListAsync();
        }

        public async Task<List<Flights>> GetMostExpensiveFlightsAsync()
        {
            return await _appDbContext.Flights.Where(X => X.Rating >= MIN_RATING).ToListAsync();
        }

        public async Task CancelFlightReservation(int FlightId)
        {
            var FoundFlight = await GetFlightById(FlightId);
            var user = await _accountService.GetLoggedInUserAsync();

            if (FoundFlight != null && user != null) {

                var FlightReservationToRemove = await _appDbContext.BookedFlights.Include(x => x.Flights).FirstOrDefaultAsync(x => x.Flights.Id == FoundFlight.Id && x.user.Id == user.Id);

                if (FlightReservationToRemove == null)
                {
                    return;
                }

                user.Points -= 1;
                _appDbContext.BookedFlights.Remove(FlightReservationToRemove);
                await _appDbContext.SaveChangesAsync();
            }

        }

        public async Task<BookedFlights> GetBookedFlightById(int FlightId)
        {
            var FoundFlight = await GetFlightById(FlightId);
            return await _appDbContext.BookedFlights.FirstOrDefaultAsync(x => x.Flights.Id == FoundFlight.Id);
        }

        public async Task<List<Flights>> GetFilteredFlightsByPrice(decimal? minPrice, decimal? maxPrice)
        {
            IQueryable<Flights> query = _appDbContext.Flights.AsQueryable();

            // Filter hotels by price range if provided
            if (minPrice != null && maxPrice != null)
            {
                query = query.Where(h => h.Price >= minPrice && h.Price <= maxPrice);
            }

            // Filter hotels by amenities if provided
           

            return await query.ToListAsync();
        }

    }
}
