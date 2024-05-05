using Hotel.org.DTO;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.org.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountservice;

        public AccountController(IAccountService accountservice)
        {
            _accountservice = accountservice;
        }

        public IActionResult RegisterPage()
        {
            return View();
        }
        public IActionResult LogInPage()
        {
            return View();
        }


        public IActionResult ProfilePage()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpPost("registeruser")]


        public async Task<IActionResult> RegisterUser(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                await _accountservice.RegisterUser(registerViewModel);
                return RedirectToAction("Index", "Home");
            }
         return View("RegisterPage", registerViewModel);

        }


        [HttpPost("loginuser")]


        public async Task<IActionResult> LogInUser(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
   await _accountservice.SignInUser(loginViewModel);
            return RedirectToAction("Index", "Home");
            }
         return View( "LogInPage", loginViewModel);
        }

        [HttpPost("logoutuser")]


        public async Task<IActionResult> LogOutUser()
        {

            await _accountservice.SignOutUser();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("saveusercarddetails")]

        public async Task<IActionResult> SaveUserCardDetails(User user) {
            if (ModelState.IsValid)
            {
                await _accountservice.SaveCardDetailsForUser(user);
                return RedirectToAction("Success", "Account");
            }
                return View("ProfilePage", user);

        }

        [HttpPost("updateusercarddetails")]

        public async Task<IActionResult> UpdateUserCardDetails(User user)
        {
            if (ModelState.IsValid)
            {
                await _accountservice.UpdateCardDetailsForUser(user);
                return RedirectToAction("Success", "Account");
            }
            return View("ProfilePage", user);

        }


        [HttpPost("updateuserprofile")]
        public async Task<IActionResult> UpdateProfileCredentials(IFormFile profileImage)
        {
            await _accountservice.UpdateUserProfile(profileImage);
            return RedirectToAction("ProfilePage", "Account");
        }
    }
}
