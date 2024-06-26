﻿using System.ComponentModel.DataAnnotations;

namespace Hotel.org.Models
{
    public class BookedHotels
    {
        [Key]
        public  int Id { get; set; }

        public int  HotelId { get; set; }

        public Hotels hotel { get; set; }

        public string AddedBy { get; set; }

        public string BookedHotelImage { get; set; }

        public string UserId { get; set; }

        public User user { get; set; }


        public decimal? PaidAtBooking { get; set; }
    }
}
