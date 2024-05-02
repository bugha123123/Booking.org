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

        public async Task<IActionResult> HotelSearchPage(string? place, string? checkInDate, string? checkOutDate, string? AdultsCount, string? ChildrenCount)
        {
            var result = await _hotelService.SearchForHotel(place, checkInDate, checkOutDate, AdultsCount, ChildrenCount);
            return View(result);
        }
        [Authorize]
        public IActionResult HotelBookedSuccessPage()
        {
            return View();
        }

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

        public async Task<IActionResult> AllHotelsPage()
        {
            var hotels = await _hotelService.GetAllHotelsForDropDown();
            return View(hotels);

        }
        //books hotel
        [HttpPost("bookhotel")]
        public async Task<IActionResult> BookHotel(int HotelId, string cardNumber, string cvc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _hotelService.BookHotel(HotelId, cardNumber, cvc);

                    return RedirectToAction("HotelBookedSuccessPage", "Hotel");
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



    }
}
