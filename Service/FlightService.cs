using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.Service
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAccountService _accountService;

        public FlightService(AppDbContext appDbContext, IAccountService accountService)
        {
            _appDbContext = appDbContext;
            _accountService = accountService;
        }



        public async Task<List<Flights>> GetAllFlightsForDropDown()
        {
            return await _appDbContext.Flights.Include(x => x.Hotel).ToListAsync();
                
        }

        public async Task<Flights> GetFlightById(int Id)
        {
            return await _appDbContext.Flights.FirstOrDefaultAsync(x => x.Id == Id);
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


        public async Task AddReviewForFlight(Reviews reviews)
        {
            var user = await _accountService.GetLoggedInUserAsync();

            var NewReview = new Reviews()
            {
                AddedBy = user.UserName,
                Comment = reviews.Comment,
                Stars = reviews.Stars,
AddedForFlight = reviews.AddedForFlight,
                user = user,
                UserId = user.Id,
                Type = Reviews.ReviewType.Flight,




            };


            await _appDbContext.reviews.AddAsync(NewReview);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<Reviews>> GetReviewsForFlight(int HotelId)
        {
            var FoundeFlight = await GetFlightById(HotelId);

            var foundReviews = await _appDbContext.reviews.Include(u => u.user).Where(r => r.AddedForFlight == FoundeFlight.To).ToListAsync();

            return foundReviews;

        }

    }
}
