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


        Task<bool> IsFlightBookedAsync(int FlightId);

        Task<List<Hotels>> GetHotelsAssociatedToFlight(int FlightId);

        Task AddFlightToFavourites(int FlightId);

        Task<bool> IsFlightAlreadyFavouritedByUser(User user, Flights flight);

        Task<List<FavouritedFlights>> GetFavouriteFlightsForUser();

        Task RemoveFlightsFromFavourites(int HotelId);

        Task<List<BookedFlights>> GetBookedFlights();

        Task<List<Flights>> GetTopRatedFlightsAsync();

        Task<List<Flights>> GetMostExpensiveFlightsAsync();

        Task CancelFlightReservation(int FlightId);

        Task<BookedFlights> GetBookedFlightById(int FlightId);

        Task<List<Flights>> GetFilteredFlightsByPrice(decimal? minPrice, decimal? maxPrice);
    }
}
