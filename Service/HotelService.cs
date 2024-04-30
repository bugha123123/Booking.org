using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;
using static Hotel.org.Models.Hotels;

namespace Hotel.org.Service
{
    public class HotelService : IHotelService
    {

        private readonly AppDbContext _appDbContext;

        public HotelService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        //takes 8 hotels
        public async Task<List<Hotels>> GetHotelsAsync()
        {
        return    await _appDbContext.Hotels.Take(8).ToListAsync(); 
        }

        //searches for hotel using query
        public async Task<List<Hotels>> SearchForHotel(string? place, string? checkInDate, string? checkOutDate, string? AdultsCount, string? ChildrenCount)
        {
            var query = _appDbContext.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(place))
            {
                query = query.Where(hotel => hotel.City.ToLower().Contains(place.ToLower()));
            }

         

            if (!string.IsNullOrEmpty(AdultsCount) && Enum.TryParse<NumberOfAdultsEnum>(AdultsCount, out var adults))
            {
                query = query.Where(hotel => hotel.NumberOfAdults == adults);
            }

            if (!string.IsNullOrEmpty(ChildrenCount) && Enum.TryParse<NumberOfChildrenEnum>(ChildrenCount, out var children))
            {
                query = query.Where(hotel => hotel.NumberOfChildren == children);
            }

            // Execute the query and return the filtered hotels
            return await query.ToListAsync();
        }


    }
}
