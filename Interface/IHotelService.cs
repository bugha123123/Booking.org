using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface IHotelService
    {
        //gets 8 hotels
        Task<List<Hotels>> GetHotelsAsync();

        //searches for hotels using query

        Task<List<Hotels>> SearchForHotel(string? place, string? checkInDate, string? checkOutDate, string? AdultsCount, string? ChildrenCount );
    }
}
