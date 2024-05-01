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

        //books hotel
        [HttpPost("bookhotel")]
        public async Task<IActionResult> BookHotel(int HotelId)
        {
            // Book the hotel
            await _hotelService.BookHotel(HotelId);

            return RedirectToAction("HotelBookedSuccessPage", new { HotelId = HotelId });
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
