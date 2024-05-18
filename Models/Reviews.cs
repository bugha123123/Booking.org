using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class Reviews
    {
        public enum Rating
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
        public enum ReviewType
        {
            Flight,
            Hotel
        }


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Review Comment Required")]
        public string Comment { get; set; }

        public string AddedBy { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public Rating Stars { get; set; }

        public ReviewType Type { get; set; }

        public string? AddedForHotel { get; set; }

        public string? AddedForFlight { get; set; }

        public User user { get; set; }

        public string UserId { get; set; }
    }
}
