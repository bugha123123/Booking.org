using Hotel.org.Interface;
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

    }
}
