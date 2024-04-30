using Microsoft.AspNetCore.Identity;

namespace Hotel.org.Models
{
    public class User : IdentityUser
    {

        public List<string>? BookedHotelRooms { get; set; }


    }
}
