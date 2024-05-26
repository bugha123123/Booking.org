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
            From = "New York City (JFK Airport)",
            FromLat = 40.6444,
            FromLong = -73.9740,
            To = "The Ritz-Carlton, Tokyo",
            DepartureTime = new DateTime(2024, 6, 1, 8, 0, 0),
            ArrivalTime = new DateTime(2024, 6, 1, 10, 0, 0),
            Price = 150.00M,
            Airline = "American Airlines (AA)",
            FlightNumber = "AA123",
            Image = "/Images/flight1.jpg",
            Description = "Non-stop flight from New York City to Miami",
            Rating = 4.5,
            HotelId = 1 // Linking to Luxury Resort
        },
        new Models.Flights
        {
            Id = 2,
            From = "Los Angeles, California (LAX Airport)",
            FromLat = 34.0522,
            FromLong = -118.2437,
            To = "Hotel de Paris Monte-Carlo",
            DepartureTime = new DateTime(2024, 7, 1, 9, 0, 0),
            ArrivalTime = new DateTime(2024, 7, 1, 11, 0, 0),
            Price = 200.00M,
            Airline = "United Airlines (UA)",
            FlightNumber = "BB234",
            Image = "/Images/flight2.jpg",
            Description = "Non-stop flight from Los Angeles to Denver",
            Rating = 4.0,
            HotelId = 2 // Linking to Mountain Lodge
        },
        new Models.Flights
        {
            Id = 3,
            From = "Chicago, Illinois (ORD Airport)",
            FromLat = 41.8819,
            FromLong = -87.8986,
            To = "The Plaza Hotel",
            DepartureTime = new DateTime(2024, 8, 1, 10, 0, 0),
            ArrivalTime = new DateTime(2024, 8, 1, 12, 0, 0),
            Price = 250.00M,
            Airline = "Delta Air Lines (DL)",
            FlightNumber = "CC345",
            Image = "/Images/flight3.jpg",
            Description = "Non-stop flight from Chicago to Seattle",
            Rating = 4.3,
            HotelId = 3 // Linking to City Center Hotel
        },
        new Models.Flights
        {
            Id = 4,
            From = "Dallas, Texas (DFW Airport)",
            FromLat = 32.8547,
            FromLong = -97.0928,
            To = "Burj Al Arab",
            DepartureTime = new DateTime(2024, 9, 1, 11, 0, 0),
            ArrivalTime = new DateTime(2024, 9, 1, 13, 0, 0),
            Price = 220.00M,
            Airline = "American Airlines (AA)",
            FlightNumber = "DD456",
            Image = "/Images/flight4.jpg",
            Description = "Non-stop flight from Dallas to Honolulu",
            Rating = 4.7,
            HotelId = 4 // Linking to Coastal Retreat
        },
                new Models.Flights
                {
                    Id = 5,
                    From = "Washington D.C. (DCA Airport)",
                    FromLat = 38.8951,
                    FromLong = -77.0367,
                    To = "The Savoy Hotel",
                    DepartureTime = new DateTime(2024, 10, 1, 12, 0, 0),
                    ArrivalTime = new DateTime(2024, 10, 1, 14, 0, 0),
                    Price = 180.00M,
                    Airline = "Southwest Airlines (WN)",
                    FlightNumber = "EE567",
                    Image = "/Images/flight5.jpg",
                    Description = "Non-stop flight from Washington D.C. to Atlanta",
                    Rating = 3.9,
                    HotelId = 5 // Linking to Rural Farmstay
                },
        new Models.Flights
        {
            Id = 6,
            From = "San Francisco, California (SFO Airport)",
            FromLat = 37.6189,
            FromLong = -122.3777,
            To = "Raffles Hotel",
            DepartureTime = new DateTime(2024, 11, 1, 13, 0, 0),
            ArrivalTime = new DateTime(2024, 11, 1, 15, 0, 0),
            Price = 190.00M,
            Airline = "United Airlines (UA)",
            FlightNumber = "FF678",
            Image = "/Images/flight6.jpg",
            Description = "Non-stop flight from San Francisco to Austin",
            Rating = 4.1,
            HotelId = 6 // Linking to Urban Boutique Hotel
        },
        new Models.Flights
        {
            Id = 7,
            From = "Seattle, Washington (SEA Airport)",
            FromLat = 47.4490,
            FromLong = -122.3019,
            To = "Four Seasons Hotel George V",
            DepartureTime = new DateTime(2024, 12, 1, 14, 0, 0),
            ArrivalTime = new DateTime(2024, 12, 1, 16, 0, 0),
            Price = 210.00M,
            Airline = "Delta Air Lines (DL)",
            FlightNumber = "GG789",
            Image = "/Images/flight7.jpg",
            Description = "Non-stop flight from Seattle to Boston",
            Rating = 4.4,
            HotelId = 7 // Linking to Historic Inn
        },
        new Models.Flights
        {
            Id = 8,
            From = "Denver, Colorado (DEN Airport)",
            FromLat = 39.8647,
            FromLong = -104.6736,
            To = "The Oberoi Amarvilas",
            DepartureTime = new DateTime(2024, 12, 15, 15, 0, 0),
            ArrivalTime = new DateTime(2024, 12, 15, 17, 0, 0),
            Price = 230.00M,
            Airline = "Frontier Airlines (F9)",
            FlightNumber = "HH890",
            Image = "/Images/flight8.jpg",
            Description = "Non-stop flight from Denver to Salt Lake City",
            Rating = 4.2,
            HotelId = 8 // Linking to Ski Lodge
        },
                new Models.Flights
                {
                    Id = 9,
                    From = "Miami, Florida (MIA Airport)",
                    FromLat = 25.7617,
                    FromLong = -80.1806,
                            To = " Mandarin Oriental Bangkok ",
                    DepartureTime = new DateTime(2024, 12, 20, 16, 0, 0),
                    ArrivalTime = new DateTime(2024, 12, 20, 18, 0, 0),
                    Price = 240.00M,
                    Airline = "Spirit Airlines (NK)", // Assuming Spirit Airlines
                    FlightNumber = "II901",
                    Image = "/Images/flight9.jpg",
                    Description = "Non-stop flight from Miami to Las Vegas",
                    Rating = 4.6,
                    HotelId = 9 // Linking to Desert Oasis
                },
        new Models.Flights
        {
            Id = 10,
            From = "Atlanta, Georgia (ATL Airport)",
            FromLat = 33.6367,
            FromLong = -84.4281,
            To = "Marina Bay Sands",
            DepartureTime = new DateTime(2024, 12, 25, 17, 0, 0),
            ArrivalTime = new DateTime(2024, 12, 25, 19, 0, 0),
            Price = 250.00M,
            Airline = "Delta Air Lines (DL)",
            FlightNumber = "JJ012",
            Image = "/Images/flight10.jpg",
            Description = "Non-stop flight from Atlanta to Orlando",
            Rating = 4.8,
            HotelId = 10 // Linking to Lakefront Lodge
        }
            // Add more flight data as needed
            );
        }
    }
}
