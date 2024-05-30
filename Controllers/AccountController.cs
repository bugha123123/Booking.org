using Hotel.org.DTO;
using Hotel.org.Interface;
using Hotel.org.Models;
using Hotel.org.Service;
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


        public IActionResult VerificationPage()
        {
            return View();
        }
        [HttpPost("registeruser")]


        public async Task<IActionResult> RegisterUser(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                
             var result =    await _accountservice.RegisterUser(registerViewModel);
                if (result)
                {
                    return RedirectToAction("VerificationPage", "Account");

                }
                else {
                    ViewData["EmailExists"] = "Error Registering try again!!!";
                    return View("RegisterPage", registerViewModel);
                }

            }
         return View("RegisterPage", registerViewModel);

        }


        [HttpPost("loginuser")]


        public async Task<IActionResult> LogInUser(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var isSignInSuccessful = await _accountservice.SignInUser(loginViewModel);

                if (isSignInSuccessful)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your email and password.");
                }
            }

            return View("LogInPage", loginViewModel);
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

        [HttpPost("deleteuser")]
        public async Task<IActionResult> DeleteUser()
        {
            await _accountservice.DeleteUser();
            return RedirectToAction("RegisterPage", "Account");
        }

        [HttpPost("verifycode")]
        public async Task<IActionResult> VerifyCode(string code)
        {
         var VerificationResult =    await _accountservice.VerifyVerificationCode(code);

            if (VerificationResult)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("VerificationPage", "Account");
        }
    }
}
