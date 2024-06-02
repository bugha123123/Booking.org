using Hotel.org.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.org.Controllers
{
    public class RentalCarsController : Controller
    {
        private readonly ICarService _carService;

        public RentalCarsController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult RentalCarsMainPage()
        {
            return View();
        }

        public async Task<IActionResult> CarSearch(string? location, string? startDate, string? EndDate)
        {
            var searchResult = await _carService.SearchForRentalCars(location, startDate, EndDate);
        
           
                return View(searchResult);
       
  
        }
    }
}
