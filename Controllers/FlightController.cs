using Hotel.org.Interface;
using Hotel.org.Models;
using Hotel.org.Service;
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
        public async Task<IActionResult> FlightDetailsPage(int FlightId)
        {
            var foundFlight = await _flightService.GetFlightById(FlightId);
            return View(foundFlight);
        }

        public async Task<IActionResult> FlightSearchPage(string? departureLocation, string? destination, string? departureTime, string? arrivalTime)
        {
            var flights = await _flightService.SearchForFlight(departureLocation, destination, departureTime, arrivalTime);
            return View(flights);
        }



        [HttpPost("addreviewforflight")]

        public async Task<IActionResult> AddReviewForFlight(Reviews reviews)
        {

            await _flightService.AddReviewForFlight(reviews);
            return RedirectToAction("ReviewSuccessPage", "Hotel");



        }
    }
}
