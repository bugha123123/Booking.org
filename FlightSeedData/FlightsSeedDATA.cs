using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.org.FlightSeedDATA
{
    public class FlightSeedData : IEntityTypeConfiguration<Models.Flights>
    {
        public void Configure(EntityTypeBuilder<Models.Flights> builder)
        {
            builder.HasData(
                new Models.Flights
                {
                    Id = 1,
                    From = "City A",
                    To = "Luxury Resort",
                    DepartureTime = new DateTime(2024, 6, 1, 8, 0, 0),
                    ArrivalTime = new DateTime(2024, 6, 1, 10, 0, 0),
                    Price = 150.00M,
                    Airline = "Airline A",
                    FlightNumber = "AA123",
                    Image = "/Images/flight1.jpg",
                    Description = "Non-stop flight from City A to Paradise City",
                    Rating = 4.5,
                    HotelId = 1  // Linking to Luxury Resort
                },
                new Models.Flights
                {
                    Id = 2,
                    From = "City C",
                    To = "Mountain Village",
                    DepartureTime = new DateTime(2024, 7, 1, 9, 0, 0),
                    ArrivalTime = new DateTime(2024, 7, 1, 11, 0, 0),
                    Price = 200.00M,
                    Airline = "Airline B",
                    FlightNumber = "BB234",
                    Image = "/Images/flight2.jpg",
                    Description = "Non-stop flight from City C to Mountain Village",
                    Rating = 4.0,
                    HotelId = 2  // Linking to Mountain Lodge
                },
                new Models.Flights
                {
                    Id = 3,
                    From = "City E",
                    To = "Paradise City",
                    DepartureTime = new DateTime(2024, 8, 1, 10, 0, 0),
                    ArrivalTime = new DateTime(2024, 8, 1, 12, 0, 0),
                    Price = 250.00M,
                    Airline = "Airline C",
                    FlightNumber = "CC345",
                    Image = "/Images/flight3.jpg",
                    Description = "Non-stop flight from City E to Paradise City",
                    Rating = 4.3,
                    HotelId = 3  // Linking to City Center Hotel
                },
                new Models.Flights
                {
                    Id = 4,
                    From = "City G",
                    To = "Oceanfront Town",
                    DepartureTime = new DateTime(2024, 9, 1, 11, 0, 0),
                    ArrivalTime = new DateTime(2024, 9, 1, 13, 0, 0),
                    Price = 220.00M,
                    Airline = "Airline D",
                    FlightNumber = "DD456",
                    Image = "/Images/flight4.jpg",
                    Description = "Non-stop flight from City G to Oceanfront Town",
                    Rating = 4.7,
                    HotelId = 4  // Linking to Coastal Retreat
                },
                new Models.Flights
                {
                    Id = 5,
                    From = "City H",
                    To = "Ruralville",
                    DepartureTime = new DateTime(2024, 10, 1, 12, 0, 0),
                    ArrivalTime = new DateTime(2024, 10, 1, 14, 0, 0),
                    Price = 180.00M,
                    Airline = "Airline E",
                    FlightNumber = "EE567",
                    Image = "/Images/flight5.jpg",
                    Description = "Non-stop flight from City H to Ruralville",
                    Rating = 3.9,
                    HotelId = 5  // Linking to Rural Farmstay
                },
                new Models.Flights
                {
                    Id = 6,
                    From = "City I",
                    To = "Hipsterville",
                    DepartureTime = new DateTime(2024, 11, 1, 13, 0, 0),
                    ArrivalTime = new DateTime(2024, 11, 1, 15, 0, 0),
                    Price = 190.00M,
                    Airline = "Airline F",
                    FlightNumber = "FF678",
                    Image = "/Images/flight6.jpg",
                    Description = "Non-stop flight from City I to Hipsterville",
                    Rating = 4.1,
                    HotelId = 6  // Linking to Urban Boutique Hotel
                },
                new Models.Flights
                {
                    Id = 7,
                    From = "City J",
                    To = "Old Town",
                    DepartureTime = new DateTime(2024, 12, 1, 14, 0, 0),
                    ArrivalTime = new DateTime(2024, 12, 1, 16, 0, 0),
                    Price = 210.00M,
                    Airline = "Airline G",
                    FlightNumber = "GG789",
                    Image = "/Images/flight7.jpg",
                    Description = "Non-stop flight from City J to Old Town",
                    Rating = 4.4,
                    HotelId = 7  // Linking to Historic Inn
                },
                new Models.Flights
                {
                    Id = 8,
                    From = "City K",
                    To = "Snowy Peaks",
                    DepartureTime = new DateTime(2024, 12, 15, 15, 0, 0),
                    ArrivalTime = new DateTime(2024, 12, 15, 17, 0, 0),
                    Price = 230.00M,
                    Airline = "Airline H",
                    FlightNumber = "HH890",
                    Image = "/Images/flight8.jpg",
                    Description = "Non-stop flight from City K to Snowy Peaks",
                    Rating = 4.2,
                    HotelId = 8  // Linking to Ski Lodge
                },
                new Models.Flights
                {
                    Id = 9,
                    From = "City L",
                    To = "Sandy Valley",
                    DepartureTime = new DateTime(2024, 12, 20, 16, 0, 0),
                    ArrivalTime = new DateTime(2024, 12, 20, 18, 0, 0),
                    Price = 240.00M,
                    Airline = "Airline I",
                    FlightNumber = "II901",
                    Image = "/Images/flight9.jpg",
                    Description = "Non-stop flight from City L to Sandy Valley",
                    Rating = 4.6,
                    HotelId = 9  // Linking to Desert Oasis
                },
                new Models.Flights
                {
                    Id = 10,
                    From = "City M",
                    To = "Lakeland",
                    DepartureTime = new DateTime(2024, 12, 25, 17, 0, 0),
                    ArrivalTime = new DateTime(2024, 12, 25, 19, 0, 0),
                    Price = 250.00M,
                    Airline = "Airline J",
                    FlightNumber = "JJ012",
                    Image = "/Images/flight10.jpg",
                    Description = "Non-stop flight from City M to Lakeland",
                    Rating = 4.8,
                    HotelId = 10  // Linking to Lakefront Lodge
                }
                // Add more flight data as needed
            );
        }
    }
}
