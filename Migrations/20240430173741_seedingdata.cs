using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "AveragePricePerNight", "Breakfast", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Parking", "Pool", "PostalCode", "Rating", "RoomImage", "RoomTypes", "Wifi" },
                values: new object[,]
                {
                    { 1, "123 Beachfront Road", 300m, true, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Paradise City", "info@luxuryresort.com", "+1234567890", "Tropical Island", "Experience ultimate luxury and relaxation at our beachfront resort.", true, "Luxury Resort", 0, 0, 100, true, true, "54321", 5, "luxury_resort.jpg", "Standard, Deluxe, Suite", true },
                    { 2, "456 Alpine Drive", 200m, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Mountain Village", "info@mountainlodge.com", "+9876543210", "Alpine Wonderland", "Escape to the mountains and enjoy cozy accommodations and breathtaking views.", true, "Mountain Lodge", 0, 0, 50, true, false, "98765", 4, "mountain_lodge.jpg", "Standard, Chalet, Cabin", true },
                    { 3, "789 Downtown Avenue", 250m, true, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Metropolis", "info@citycenterhotel.com", "+5432109876", "Urbania", "Stay in the heart of the city and explore all that Metropolis has to offer.", true, "City Center Hotel", 0, 0, 80, true, false, "12345", 4, "city_center_hotel.jpg", "Standard, Executive, Suite", true },
                    { 4, "101 Seaside Boulevard", 280m, true, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Oceanfront Town", "info@coastalretreat.com", "+9876123450", "Seaside Haven", "Relax by the sea and enjoy stunning views at our coastal retreat.", false, "Coastal Retreat", 0, 0, 120, true, true, "13579", 4, "coastal_retreat.jpg", "Standard, Ocean View, Beachfront Villa", true },
                    { 5, "789 Countryside Lane", 150m, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Ruralville", "info@ruralfarmstay.com", "+1357924680", "Countryland", "Experience farm life and unwind in the tranquility of the countryside.", false, "Rural Farmstay", 0, 0, 20, true, false, "24680", 3, "rural_farmstay.jpg", "Farmhouse, Cottage", false },
                    { 6, "321 Trendy Street", 180m, true, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Hipsterville", "info@urbanboutiquehotel.com", "+6789012345", "Trendyland", "Immerse yourself in the vibrant culture of Hipsterville at our trendy boutique hotel.", true, "Urban Boutique Hotel", 0, 0, 40, true, false, "86420", 4, "urban_boutique_hotel.jpg", "Standard, Loft, Penthouse", true },
                    { 7, "456 Heritage Lane", 170m, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Old Town", "info@historicinn.com", "+5432198765", "Nostalgia", "Step back in time and stay in a charming historic inn in the heart of Old Town.", false, "Historic Inn", 0, 0, 25, true, false, "97531", 4, "historic_inn.jpg", "Classic Room, Suite", true },
                    { 8, "789 Mountain Road", 220m, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Snowy Peaks", "info@skilodge.com", "+9876543210", "Winterland", "Hit the slopes and cozy up by the fire at our charming ski lodge.", false, "Ski Lodge", 0, 0, 60, true, false, "36984", 4, "ski_lodge.jpg", "Standard, Chalet", true },
                    { 9, "321 Sand Dune Drive", 160m, true, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Sandy Valley", "info@desertoasis.com", "+1234567890", "Dunescape", "Experience the beauty of the desert and unwind in our luxurious oasis.", false, "Desert Oasis", 0, 0, 30, true, true, "75319", 3, "desert_oasis.jpg", "Standard Tent, Deluxe Tent", false },
                    { 10, "147 Lakeside Avenue", 190m, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Lakeland", "info@lakefrontlodge.com", "+6789012345", "Lakelandia", "Escape to the serene beauty of the lake and relax at our charming lakefront lodge.", false, "Lakefront Lodge", 0, 0, 35, true, false, "58204", 4, "lakefront_lodge.jpg", "Standard, Lakeside Suite", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
