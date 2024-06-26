﻿using Hotel.org.DTO;
using Hotel.org.Interface;
using Hotel.org.Models;
using Hotel.org.Service;
using Microsoft.AspNetCore.Mvc;
using static Hotel.org.Models.Reviews;

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
        public IActionResult FlightBookedSuccessPage()
        {
            return View();
        }
        public async Task<IActionResult> AllFlightsPage(decimal? minPrice, decimal? maxPrice,int page = 1)
        {

            const int PageSize = 4; // Define the number of hotels per page
            List<Flights> Flights;

            // If no filters are provided, return all hotels without applying any filters
            if (minPrice == null && maxPrice == null || minPrice == 0 && maxPrice == 0)
            {
                Flights = await _flightService.GetAllFlightsForDropDown();
            }
            else
            {
                // Apply the provided filters
                Flights = await _flightService.GetFilteredFlightsByPrice(minPrice, maxPrice);
            }

            // Implement paging
            var totalPages = (int)Math.Ceiling((double)Flights.Count / PageSize);
            var currentPageFlights = Flights.Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Pass the current page and total pages to the view
            var model = new AllFlightsViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Flights = currentPageFlights
            };

            return View(model);
        }

        public async Task<IActionResult> ViewFlightReservationsPage(int FlightId)
        {
            var FoundFlightById = await _flightService.GetBookedFlightById(FlightId);
            return View(FoundFlightById);
        }

        public async Task<IActionResult> FlightReservationsPage()
        {
            var flights = await _flightService.GetBookedFlights();
            return View(flights);
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

                    return RedirectToAction("FlightBookedSuccessPage", new { FlightId = FlightId });
                }
                else
                {
                    // If model state is not valid, return to the CheckOutPage with validation errors
                    return RedirectToAction("FlightCheckOutPage", new { FlightId = FlightId });
                }
            }
            catch (ArgumentException)
            {
                // Handle the case of wrong card credentials
                ViewData["WrongCardCredentials"] = "Wrong Card Credentials. Try again!";
                return RedirectToAction("FlightCheckOutPage", new { FlightId = FlightId });
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ViewData["ErrorMessage"] = "An error occurred while booking the hotel. Please try again later.";
                // Optionally log the exception for further investigation
                return RedirectToAction("FlightCheckOutPage", new { FlightId = FlightId });
            }
        }


        [HttpPost("addflighttofavourites")]

        public async Task<IActionResult> AddFlightToFavorites(int FlightId)
        {
            try
            {
                await _flightService.AddFlightToFavourites(FlightId);
                return RedirectToAction("FavouritedHotelsPage", "Hotel");
            }
            catch (Exception)
            {

                ViewData["HotelAlreadyBooked"] = "You have already booked this flight";
                return RedirectToAction("FlightMainPage", "Flight");
            }
        }


        [HttpPost("removeflightfromfavourites")]

        public async Task<IActionResult> RemoveFlightFromFavorites(int FlightId)
        {

            await _flightService.RemoveFlightsFromFavourites(FlightId);
            return RedirectToAction("FavouritedHotelsPage", "Hotel");

        }


        [HttpPost("removeflightreservation")]

        public async Task<IActionResult> CancelFlightReservation(int FlightId)
        {

            await _flightService.CancelFlightReservation(FlightId);
            return RedirectToAction("FlightReservationsPage", "Flight");

        }
    }
}
