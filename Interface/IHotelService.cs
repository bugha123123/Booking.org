using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface IHotelService
    {
        //gets 8 hotels
        Task<List<Hotels>> GetHotelsAsync();

        //searches for hotels using query

        Task<List<Hotels>> SearchForHotel(string? place, string? checkInDate, string? checkOutDate, string? AdultsCount, string? ChildrenCount );

        //books a hotel for user

        Task BookHotel(int HotelId);

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
        Task<List<Hotels>> GetFilteredHotelsByPrice(decimal? minPrice, decimal? maxPrice);
    }
}
