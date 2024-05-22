using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class BookedFlights
    {

        [Key]
        public int Id { get; set; }

        public int FlightId { get; set; }

        public Flights Flights { get; set; }



        public string UserId { get; set; }

        public User user { get; set; }

    }
}
