using Hotel.org.ApplicationDBContext;
using Hotel.org.DTO;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.AspNetCore.Identity;

namespace Hotel.org.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbcontext;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor, AppDbContext dbcontext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _dbcontext = dbcontext;
        }

        public async Task<User> GetLoggedInUserAsync()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name!;

            // Find the user by username
            var user = await _userManager.FindByNameAsync(userName);

            return user;
        }



        //registers user using identity
        public async Task RegisterUser(RegisterViewModel registerViewModel)
        {
            var user = new User
            {
                UserName = registerViewModel.EmailAddress,
                Email = registerViewModel.EmailAddress
            };
            //gets the result
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);


            //register === success
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
        }

        public async Task SaveCardDetailsForUser(User user)
        {
            var LoggedInUser = await GetLoggedInUserAsync();

            LoggedInUser.CardCV = user.CardCV;
            LoggedInUser.CardNumber = user.CardNumber;
            LoggedInUser.CardExpirationDate = user.CardExpirationDate;

            await _dbcontext.SaveChangesAsync();


        }


        //signs in user
        public async Task SignInUser(LoginViewModel loginViewModel)
        {
             await _signInManager.PasswordSignInAsync(loginViewModel.EmailAddress, loginViewModel.Password, isPersistent:false, lockoutOnFailure: false);

        }

        public async Task SignOutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task UpdateCardDetailsForUser(User user)
        {
            var LoggedInUser = await GetLoggedInUserAsync();

            LoggedInUser.CardCV = user.CardCV;
            LoggedInUser.CardNumber = user.CardNumber;
            LoggedInUser.CardExpirationDate= user.CardExpirationDate;

            await _dbcontext.SaveChangesAsync();


        }
    }
}
