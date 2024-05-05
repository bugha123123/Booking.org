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

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Review Comment Required")]
        public string Comment { get; set; }

        public string AddedBy { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public Rating Stars { get; set; }

        public string AddedForHotel { get; set; }
    }
}
