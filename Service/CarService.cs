using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.Service
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RentalCars>> GetRentalCarsAsync()
        {
            return await _context.RentalCars.Take(8).ToListAsync();
        }
        public async Task<List<RentalCars>> SearchForRentalCars(string? location, string? startDate, string? endDate)
        {
            var query = _context.RentalCars.AsQueryable();

            // Filter by location
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(car => car.Location.ToLower().Contains(location.ToLower()));
            }

            // Filter by start and end dates
            if (!string.IsNullOrEmpty(startDate) && DateTime.TryParse(startDate, out DateTime start) &&
                !string.IsNullOrEmpty(endDate) && DateTime.TryParse(endDate, out DateTime end))
            {
                query = query.Where(car => car.PickupDate <= start && car.DropoffDate >= end);
            }

            // Execute the query and return the filtered rental cars
            return await query.ToListAsync();
        }

    }
}
