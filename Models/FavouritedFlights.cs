using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class FavouritedFlights
    {

        [Key]
        public int Id { get; set; }


        public Flights flight { get; set; }

        public int FlightId { get; set; }

        public User user { get; set; }

        public string UserId { get; set; }

    }
}
