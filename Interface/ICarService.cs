using Hotel.org.Models;

namespace Hotel.org.Interface
{
    public interface ICarService
    {

        Task<List<RentalCars>> GetRentalCarsAsync();

        Task<List<RentalCars>> SearchForRentalCars(string? location, string? startDate, string? endData);
    }
}
