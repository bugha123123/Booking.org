using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Card number is required.")]
        [RegularExpression("^[0-9]{16}$", ErrorMessage = "Card number must be a 16-digit number.")]
        public string? CardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Card expiration date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CardExpirationDate { get; set; } = default(DateTime);

        [Required(ErrorMessage = "Card CV is required.")]
        [RegularExpression("^[0-9]{3}$", ErrorMessage = "Card CV must be a 3-digit number.")]
        public string? CardCV { get; set; } = string.Empty;

    }
}
