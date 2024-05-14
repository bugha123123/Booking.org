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

        public IActionResult AllUserReviewsPage()
        {
            return View();
        }

        public IActionResult AllUserDataPage()
        {
            return View();
        }
    }
}
