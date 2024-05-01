using System.ComponentModel.DataAnnotations; 


namespace Hotel.org.DTO
{
    // Public class declaration for LoginViewModel
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        
        [Compare("Password", ErrorMessage = "Passwords do not match")] // Compares ConfirmPassword to Password
        public string ConfirmPassword { get; set; }
    }
}
