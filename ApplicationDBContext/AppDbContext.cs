using Hotel.org.FlightSeedDATA;
using Hotel.org.HotelSeedData;
using Hotel.org.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.ApplicationDBContext
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<BookedHotels> bookedHotels { get; set; }

        public DbSet<Reviews> reviews { get; set; }

        public DbSet<Support> Supports { get; set; }

        public DbSet<Favourites> Favourites { get; set; }

        public DbSet<Flights> Flights { get; set; }

        public DbSet<BookedFlights> BookedFlights { get; set; }

        public DbSet<FavouritedFlights> FavouritedFlights { get; set; }

        public DbSet<RentalCars> RentalCars { get; set; }

        public DbSet<UserVerificationCode> UserVerificationCodes { get; set; }  
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfiguration(new HotelData());

            modelBuilder.ApplyConfiguration(new FlightSeedData());

            modelBuilder.ApplyConfiguration(new CarRentalSeedData());

            modelBuilder.Entity<User>().HasData(
        new User
        {
            
            UserName = "admin@example.com",
            NormalizedUserName = "ADMIN@EXAMPLE.COM",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<User>().HashPassword(null, "Admin"),
            UserRole = "ADMIN"
        }
    );
        }
    }
}
