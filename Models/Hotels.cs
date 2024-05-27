using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class Hotels
    {
        public enum NumberOfChildrenEnum
        {
            [Display(Name = "0")]
            None = 0,

            [Display(Name = "1")]
            One = 1,

            [Display(Name = "2")]
            Two = 2,

            [Display(Name = "3")]
            Three = 3,

            [Display(Name = "4")]
            Four = 4,

            [Display(Name = "5")]
            Five = 5
        }

        public enum NumberOfAdultsEnum
        {
            [Display(Name = "0")]
            None = 0,

            [Display(Name = "1")]
            One = 1,

            [Display(Name = "2")]
            Two = 2,

            [Display(Name = "3")]
            Three = 3,

            [Display(Name = "4")]
            Four = 4,

            [Display(Name = "5")]
            Five = 5
        }



        [Key]
        public int Id { get; set; }

        // Basic Information
        [Required(ErrorMessage = "Hotel name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hotel address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Display(Name = "Contact Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }

        [Display(Name = "Contact Phone")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string ContactPhone { get; set; }

        [Display(Name = "Number of Children")]
        public NumberOfChildrenEnum NumberOfChildren { get; set; }

        [Display(Name = "Number of Adults")]
        public NumberOfAdultsEnum NumberOfAdults { get; set; }

        // Amenities
        public bool Wifi { get; set; }

        public bool Parking { get; set; }

        public bool Breakfast { get; set; }

        public bool Gym { get; set; }

        public bool Pool { get; set; }

        // Room Features
        [Display(Name = "Number of Rooms")]
        public int NumberOfRooms { get; set; }

        [Display(Name = "Room Types Available")]
        public string RoomTypes { get; set; }

        // Additional Information
        [Display(Name = "Check-In Time")]
        public TimeSpan CheckInTime { get; set; }

        public string RoomImage { get; set; }

        [Display(Name = "Check-Out Time")]
        public TimeSpan CheckOutTime { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Average Price Per Night")]
        public decimal AveragePricePerNight { get; set; }

        [Display(Name = "Rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public User? user { get; set; }

        public string? UserId { get; set; }

        public double lat { get; set; }

        public double longitute { get; set; }

        public double PaidA
        {
            get; set;


        }
    }
}
