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

        public async Task<IActionResult> FlightCheckOutPage(int FlightId)
        {
            var FlightById = await _flightService.GetFlightById(FlightId);

            return View(FlightById);
        }

        [HttpPost("addreviewforflight")]

        public async Task<IActionResult> AddReviewForFlight(Reviews reviews)
        {

            await _flightService.AddReviewForFlight(reviews);
            return RedirectToAction("ReviewSuccessPage", "Hotel");



        }


        [HttpPost("bookflight")]
        public async Task<IActionResult> BookFlight(int FlightId, string cardNumber, string cvc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _flightService.BookFlight(FlightId, cardNumber, cvc);

                    return RedirectToAction("HotelBookedSuccessPage", new { FlightId = FlightId });
                }
                else
                {
                    // If model state is not valid, return to the CheckOutPage with validation errors
                    return RedirectToAction("CheckOutPage", new { FlightId = FlightId });
                }
            }
            catch (ArgumentException)
            {
                // Handle the case of wrong card credentials
                ViewData["WrongCardCredentials"] = "Wrong Card Credentials. Try again!";
                return RedirectToAction("CheckOutPage", new { FlightId = FlightId });
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ViewData["ErrorMessage"] = "An error occurred while booking the hotel. Please try again later.";
                // Optionally log the exception for further investigation
                return RedirectToAction("CheckOutPage", new { FlightId = FlightId });
            }
        }
    }
}
