namespace Hotel.org.Models
{
    public class RentalCars
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal PricePerDay { get; set; }

        public DateTime? PickupDate { get; set; }
        public DateTime? DropoffDate { get; set; }
    }
}
