using Hotel.org.HotelSeedData;
using Hotel.org.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.ApplicationDBContext
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<BookedHotels> bookedHotels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfiguration(new HotelData());
        }
    }
}
