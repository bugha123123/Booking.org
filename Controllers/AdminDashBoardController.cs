using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.org.Controllers
{
    public class AdminDashBoardController : Controller
    {
        [Authorize]
        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
