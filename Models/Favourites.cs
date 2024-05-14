using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class Favourites
    {
        [Key]
        public int Id { get; set; }

        public string FavoutiredHotelName { get; set; }

        public  Hotels hotel{ get; set; }

        public int HotelId { get; set; }

        public User user { get; set; }

        public string UserId { get; set; }
    }
}
