using System.ComponentModel.DataAnnotations;

namespace Hotel.org.DTO
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
