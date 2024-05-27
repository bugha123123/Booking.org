using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Hotel.org.FlightSeedDATA
{
    public class CarRentalSeedData : IEntityTypeConfiguration<Models.RentalCars>
    {
        public void Configure(EntityTypeBuilder<Models.RentalCars> builder)
        {
            builder.HasData(
                new Models.RentalCars { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020, Location = "New York, NY", Latitude = 40.7128, Longitude = -74.0060, PricePerDay = 50m },
                new Models.RentalCars { Id = 2, Make = "Honda", Model = "Civic", Year = 2019, Location = "Los Angeles, CA", Latitude = 34.0522, Longitude = -118.2437, PricePerDay = 45m },
                new Models.RentalCars {Id = 3, Make = "Ford", Model = "Mustang", Year = 2018, Location = "Chicago, IL", Latitude = 41.8781, Longitude = -87.6298, PricePerDay = 70m },
                new Models.RentalCars {Id = 4, Make = "Chevrolet", Model = "Malibu", Year = 2021, Location = "Houston, TX", Latitude = 29.7604, Longitude = -95.3698, PricePerDay = 55m },
                new Models.RentalCars { Id = 5, Make = "Nissan", Model = "Altima", Year = 2017, Location = "Phoenix, AZ", Latitude = 33.4484, Longitude = -112.0740, PricePerDay = 40m },
                new Models.RentalCars {Id = 6, Make = "BMW", Model = "3 Series", Year = 2020, Location = "Philadelphia, PA", Latitude = 39.9526, Longitude = -75.1652, PricePerDay = 80m },
                new Models.RentalCars {Id = 7, Make = "Mercedes-Benz", Model = "C-Class", Year = 2019, Location = "San Antonio, TX", Latitude = 29.4241, Longitude = -98.4936, PricePerDay = 85m },
                new Models.RentalCars {Id = 8, Make = "Audi", Model = "A4", Year = 2021, Location = "San Diego, CA", Latitude = 32.7157, Longitude = -117.1611, PricePerDay = 90m },
                new Models.RentalCars {Id = 9, Make = "Hyundai", Model = "Sonata", Year = 2018, Location = "Dallas, TX", Latitude = 32.7767, Longitude = -96.7970, PricePerDay = 50m },
                new Models.RentalCars {Id = 10, Make = "Kia", Model = "Optima", Year = 2020, Location = "San Jose, CA", Latitude = 37.3382, Longitude = -121.8863, PricePerDay = 45m }
            );
        }
    }
}
