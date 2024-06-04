using Hotel.org.Models;

namespace Hotel.org.DTO
{
    public class AllFlightsViewModel
    {

        public List<Flights> Flights { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
