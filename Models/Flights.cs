namespace Hotel.org.Models
{
    public class Flights
    {
        public int Id { get; set; }
   
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        public int HotelId { get; set; } 
        public Hotels Hotel { get; set; }
        public string From { get; set; }
        public double FromLat { get; set; } // Latitude of departure airport
        public double FromLong { get; set; } // Longitude of departure airport
        public string To { get; set; }
        
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
