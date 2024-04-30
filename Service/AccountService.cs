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
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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


        //signs in user
        public async Task SignInUser(LoginViewModel loginViewModel)
        {
             await _signInManager.PasswordSignInAsync(loginViewModel.EmailAddress, loginViewModel.Password, isPersistent:false, lockoutOnFailure: false);

        }

        public async Task SignOutUser()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
