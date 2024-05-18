using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.Service
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _appDbContext;

        public FlightService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Flights>> GetAllFlightsForDropDown()
        {
            return await _appDbContext.Flights.Include(x => x.Hotel).ToListAsync();
                
        }

        public async Task<List<Flights>> GetFlightsAsync()
        {
            return await _appDbContext.Flights.Include(u => u.Hotel).Include(x => x.User).Take(8).ToListAsync();
        }

        public async Task<List<Flights>> SearchForFlight(string? departureLocation, string? destination, string? departureTime, string? arrivalTime)
        {
            // Parse departure and arrival times
            DateTime? parsedDepartureTime = !string.IsNullOrEmpty(departureTime) ? DateTime.Parse(departureTime) : (DateTime?)null;
            DateTime? parsedArrivalTime = !string.IsNullOrEmpty(arrivalTime) ? DateTime.Parse(arrivalTime) : (DateTime?)null;

            // Query to search for flights
            var query = _appDbContext.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(departureLocation))
            {
                query = query.Where(f => f.From == departureLocation);
            }

            if (!string.IsNullOrEmpty(destination))
            {
                query = query.Where(f => f.To == destination);
            }

            if (parsedDepartureTime.HasValue)
            {
                query = query.Where(f => f.DepartureTime >= parsedDepartureTime.Value);
            }

            if (parsedArrivalTime.HasValue)
            {
                query = query.Where(f => f.ArrivalTime <= parsedArrivalTime.Value);
            }

        

            return await query.ToListAsync();
        }
    }
}
