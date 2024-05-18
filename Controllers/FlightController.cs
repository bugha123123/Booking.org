using Hotel.org.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.org.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public IActionResult FlightMainPage()
        {
            return View();
        }

 
        public async Task<IActionResult> FlightSearchPage(string? departureLocation, string? destination, string? departureTime, string? arrivalTime)
        {
            var flights = await _flightService.SearchForFlight(departureLocation, destination, departureTime, arrivalTime);
            return View(flights);
        }
    }
}
