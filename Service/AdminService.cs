using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.Service
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAccountService _accountService;
        public AdminService(AppDbContext appDbContext, IAccountService accountService)
        {
            _appDbContext = appDbContext;
            _accountService = accountService;
        }

        public async Task<List<Reviews>> GetAllReviewsForEveryUser()
        {
            return await _appDbContext.reviews
                .Include(bh => bh.user).ToListAsync();



        }
        public async Task<List<User>> GetUserDataForEveryUser()
        {
            var user = await _accountService.GetLoggedInUserAsync();
            return await _appDbContext.Users.Where(u => u.Email != user.Email).ToListAsync();


        }


        //gets 3 hotels for admin
        public async Task<List<BookedHotels>> GetBookedHotelsForEveryUser()
        {
            return await _appDbContext.bookedHotels
                .Include(bh => bh.hotel)
                .Include(bh => bh.user)
                .Take(3)
                .ToListAsync();
        }

        public async Task<List<Reviews>> GetReviewsForEveryUser()
        {
            var Reviews = await _appDbContext.reviews.Include(u => u.user).Take(3).ToListAsync();
            return Reviews;
        }

        public async Task<List<User>> GetUsers()
        {
            var user = await _accountService.GetLoggedInUserAsync();
            return await _appDbContext.Users.Take(3).Where(u => u.Email != user.Email).ToListAsync();
        }
    }
}
