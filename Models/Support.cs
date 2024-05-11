using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class Support
    {
        [Key]
        public int Id { get; set; }

        // Add required attribute to ensure a user is provided
        [Required(ErrorMessage = "User is required")]
        public User User { get; set; }

        // Add required attribute to ensure UserId is provided
        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

      
        public string AddedBy { get; set; }

        // Add required attribute to ensure Message is provided
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }

       

        // Add required attribute to ensure Subject is provided
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
    }
}
