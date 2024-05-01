using Hotel.org.DTO;
using Hotel.org.Interface;
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
    }
}
