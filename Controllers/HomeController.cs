using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.org.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISupportService _supportService;

        public HomeController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SupportPage()
        {
            return View();
        }


        [HttpPost("savesupportmessage")]

        public async Task<IActionResult> SaveSupportMessage(Support support)
        {
          
                await _supportService.AddSupportMessage(support);
                return RedirectToAction("Index", "Home");
          
         
        }
    }
}
