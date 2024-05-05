using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.Service
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _appDbContext;

        public AdminService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        


        //gets 3 hotels for admin
        public async Task<List<BookedHotels>> GetBookedHotelsForEveryUser()
        {
            return await _appDbContext.bookedHotels.Include(bh => bh.hotel).Take(3).ToListAsync();
        }

        public async Task<List<Reviews>> GetReviewsForEveryUser()
        {
            var Reviews = await _appDbContext.reviews.Take(3).ToListAsync();
            return Reviews;
        }
    }
}
