using Microsoft.AspNetCore.Mvc;

namespace Hotel.org.Controllers
{
    public class AdminDashBoardController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
