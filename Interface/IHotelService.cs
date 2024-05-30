using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface IHotelService
    {


        //gets 8 hotels
        Task<List<Hotels>> GetHotelsAsync();

        //searches for hotels using query

        Task<List<Hotels>> SearchForHotel(string? place, string? checkInTime, string? checkOutTime, string? AdultsCount, string? ChildrenCount);


        //books a hotel for user

        Task BookHotel(int hotelId, string cardNumber, string cvc);


        //gets hotel by id

        Task<Hotels> GetHotelById(int id);



        //checks if hotel is booked or not by user

        Task<bool> IsHotelBookedAsync(int hotelId);



        //gets booked hotel by id

        Task<BookedHotels> GetBookedHotelById(int hotelId);


        //gets all booked hotel for logged in user

        Task<List<BookedHotels>> GetAllBookedHotelsAsync();


        //gets all of the hotels for dropdown on index page

        Task<List<Hotels>> GetAllHotelsForDropDown();

        //cancels hotels reservation

        Task CancelReservation(int BookedHotelId);


        //gets BookedHotelById and is used for reservation canceling
        Task<BookedHotels> GetBookedHotelByIdUsedForReservationCanceling(int BookedHotelId);


        //filters hotels by prices
        Task<List<Hotels>> GetFilteredHotelsByPrice(decimal? minPrice, decimal? maxPrice, bool? hasGym, bool? hasPool, bool? hasBreakfast, int rating, int numberOfRooms);


        // Checks if the provided card number and cvc match the user's stored values

        Task<bool> ValidatePaymentDetailsAsync(User user, string cardNumber, string cvc);


        //adds review for hotel 
        Task AddReviewForHotel(Reviews reviews);

        //gets reviews for particular hotel 

        Task<List<Reviews>> GetReviewsForHotelAsync( int HotelId);

        //gets top hotels by rating

        Task<List<Hotels>> GetHotelsByRating();


        //adds hotel to favourites for particular user

        Task AddHotelToFavourites(int HotelId);

        Task<bool> IsHotelAlreadyFavouritedByUser(User user, Hotels hotel);

        Task<List<Favourites>> GetFavouriteHotelsForUser();

        Task RemoveHotelFromFavourites(int HotelId);

        //////////////////

        //gets most expensive hotels

        Task<List<Hotels>> GetExpensiveHotels();


        Task<List<Flights>> GetFlightsAssociatedToHotel(int HotelId);


        Task<bool> IsFirstTimeBooking(User user);

    }
}
