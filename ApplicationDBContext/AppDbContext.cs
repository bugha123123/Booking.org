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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfiguration(new HotelData());


            modelBuilder.Entity<User>().HasData(
        new User
        {
            
            UserName = "admin@example.com", // Set the username
            NormalizedUserName = "ADMIN@EXAMPLE.COM", // Set the normalized username
            Email = "admin@example.com", // Set the email
            NormalizedEmail = "ADMIN@EXAMPLE.COM", // Set the normalized email
            EmailConfirmed = true, // Set email confirmed flag
            PasswordHash = new PasswordHasher<User>().HashPassword(null, "Admin"),
            UserRole = "ADMIN"
        }
    );
        }
    }
}
