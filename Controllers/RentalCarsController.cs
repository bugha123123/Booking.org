using Microsoft.AspNetCore.Mvc;

namespace Hotel.org.Controllers
{
    public class RentalCarsController : Controller
    {
        public IActionResult RentalCarsMainPage()
        {
            return View();
        }
    }
}
