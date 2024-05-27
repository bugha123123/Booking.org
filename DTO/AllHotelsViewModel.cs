using Hotel.org.Models;

namespace Hotel.org.DTO
{
    public class AllHotelsViewModel
    {
        public List<Hotels> Hotels { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
