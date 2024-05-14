using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.org.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task<IActionResult> HotelSearchPage(string? place, string? checkInTime, string? checkOutTime, string? AdultsCount, string? ChildrenCount)
        {
            var result = await _hotelService.SearchForHotel(place, checkInTime, checkOutTime, AdultsCount, ChildrenCount);
            return View(result);
        }
        [Authorize]
        public IActionResult HotelBookedSuccessPage()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> CheckOutPage(int HotelId)
        {
            var hotel = await _hotelService.GetHotelById(HotelId);
            return View(hotel);
        }
        [Authorize]
        public async Task<IActionResult> ReservationsPage()
        {
            var bookedhotels = await _hotelService.GetAllBookedHotelsAsync();

         
            return View(bookedhotels);
        }

        [Authorize]
        public async Task<IActionResult> ViewReservationPage(int HotelId)
        {
            var reservedHotel = await _hotelService.GetBookedHotelById(HotelId);
            return View(reservedHotel);
        }

        [Authorize]
        public async Task<IActionResult> HotelDetailsPage(int HotelId)
        {
            var hotelbyid = await _hotelService.GetHotelById(HotelId);
            return View(hotelbyid);
        }
        [Authorize]
        public IActionResult ReviewPage()
        {
            return View();
        }
        [Authorize]
        public IActionResult ReviewSuccessPage()
        {
            return View();
        }

        public async Task<IActionResult> FavouritedHotelsPage()
        {
            var favouritedHotels = await _hotelService.GetFavouriteHotelsForUser();
            return View(favouritedHotels);
        }


        [Authorize]
        public async Task<IActionResult> AllHotelsPage(decimal? minPrice, decimal? maxPrice, bool? hasGym, bool? hasPool, bool? hasBreakfast, int rating, int numberOfRooms)
        {
            // If no filters are provided, return all hotels without applying any filters
            if (minPrice == null && maxPrice == null && hasGym == null && hasPool == null && hasBreakfast == null && rating == 0 && numberOfRooms == 0)
            {
                return View(await _hotelService.GetAllHotelsForDropDown());
            }

            // Otherwise, apply the provided filters
            var filteredHotels = await _hotelService.GetFilteredHotelsByPrice(minPrice, maxPrice, hasGym, hasPool, hasBreakfast, rating, numberOfRooms);
            return View(filteredHotels);
        }


        [HttpPost("bookhotel")]
        public async Task<IActionResult> BookHotel(int HotelId, string cardNumber, string cvc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _hotelService.BookHotel(HotelId, cardNumber, cvc);

                    return RedirectToAction("HotelBookedSuccessPage", new { HotelId = HotelId });
                }
                else
                {
                    // If model state is not valid, return to the CheckOutPage with validation errors
                    return RedirectToAction("CheckOutPage", new { HotelId = HotelId });
                }
            }
            catch (ArgumentException)
            {
                // Handle the case of wrong card credentials
                ViewData["WrongCardCredentials"] = "Wrong Card Credentials. Try again!";
                return RedirectToAction("CheckOutPage", new { HotelId = HotelId });
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ViewData["ErrorMessage"] = "An error occurred while booking the hotel. Please try again later.";
                // Optionally log the exception for further investigation
                return RedirectToAction("CheckOutPage", new { HotelId = HotelId });
            }
        }




        //removes reservation for user
        [HttpPost("cancelreservation")]
        public async Task<IActionResult> CancelReservation(int BookedHotelId)
        {
            // Book the hotel
            try
            {
                await _hotelService.CancelReservation(BookedHotelId);
                return RedirectToAction("ReservationsPage", "Hotel");
            }
            catch (Exception)
            {

                throw;
            }
            

           
        }

        [HttpPost("addreviewforhotel")]

        public async Task<IActionResult> AddReviewForHotel(Reviews reviews )
        {
          
                await _hotelService.AddReviewForHotel(reviews);
                return RedirectToAction("ReviewSuccessPage", "Hotel");
            

       
        }


        [HttpPost("addhoteltofavourites")]

        public async Task<IActionResult> AddHotelToFavorites(int HotelId)
        {
            try
            {
                await _hotelService.AddHotelToFavourites(HotelId);
                return RedirectToAction("FavouritedHotelsPage", "Hotel");
            }
            catch (Exception)
            {

                ViewData["HotelAlreadyBooked"] = "You have already booked this hotel";
                return RedirectToAction("Index", "Home");
            }
        }


    }
}
