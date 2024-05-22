using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface IFlightService
    {

        Task<List<Flights>> GetAllFlightsForDropDown();


        // used for searching flights on main flights page
        Task<List<Flights>> SearchForFlight(string? departureLocation, string? destination, string? departureTime, string? arrivalTime);


        Task<List<Flights>> GetFlightsAsync();

        Task<Flights> GetFlightById(int Id);

        Task AddReviewForFlight(Reviews reviews);

        Task<List<Reviews>> GetReviewsForFlight(int FlightId);


        Task BookFlight(int FlightId, string cardNumber, string cvc);
    }
}
