using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class adawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0d7a46b-515d-486d-a9fa-39503ee53c30");

            migrationBuilder.AddColumn<double>(
                name: "lat",
                table: "Hotels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "longitute",
                table: "Hotels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "240f6805-0d22-4876-ac8f-59a5c6fd2710", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "e161f609-fa53-463a-ba24-ae5e7f9b8e4a", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKbqUNSFwH3blQbT8skShiJ3rWjvZqer7ZfOeSz6wDNzXy7QJiG41GiPoyg5DKfx6Q==", null, false, 0, null, "df1e4ea7-dd3d-4d4a-ba24-efbcb3da0a17", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfRooms", "PostalCode", "RoomTypes", "lat", "longitute" },
                values: new object[] { "Tokyo Midtown 9-7-1 Akasaka Minato-ku", 600m, new TimeSpan(0, 15, 0, 0, 0), "Tokyo", "info@ritzcarlton-tokyo.com", "+81334231811", "Japan", "Luxurious accommodations with breathtaking views of Tokyo.", "The Ritz-Carlton, Tokyo", 245, "107-6245", "Deluxe, Executive, Suite", 35.665500000000002, 139.72970000000001 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfRooms", "Pool", "PostalCode", "RoomTypes", "lat", "longitute" },
                values: new object[] { "Place du Casino", 750m, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Monte Carlo", "info@montecarlosbm.com", "+37798062121", "Monaco", "Experience the grandeur and elegance in the heart of Monaco.", "Hotel de Paris Monte-Carlo", 182, true, "98000", "Standard, Deluxe, Suite", 43.738399999999999, 7.4256000000000002 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfRooms", "PostalCode", "Rating", "RoomTypes", "lat", "longitute" },
                values: new object[] { "768 5th Ave", 900m, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "New York", "info@theplazany.com", "+12127594600", "USA", "An iconic luxury hotel in the heart of New York City.", "The Plaza Hotel", 282, "10019", 5, "Standard, Deluxe, Suite", 40.764499999999998, -73.974199999999996 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "PostalCode", "Rating", "RoomTypes", "lat", "longitute" },
                values: new object[] { "Jumeirah St, Umm Suqeim 3", 1200m, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Dubai", "info@burjalarab.com", "+97143017777", "United Arab Emirates", "The epitome of Arabian luxury in Dubai.", true, "Burj Al Arab", 2, 3, 202, "", 5, "Standard, Deluxe, Suite", 25.141200000000001, 55.185299999999998 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes", "Wifi", "lat", "longitute" },
                values: new object[] { "Strand", 800m, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "London", "info@savoylondon.com", "+442074836000", "United Kingdom", "Historic luxury hotel in the heart of London.", true, "The Savoy Hotel", 2, 3, 267, true, "WC2R 0EZ", 5, "Standard, Deluxe, Suite", true, 51.509999999999998, -0.12 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "AveragePricePerNight", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes", "lat", "longitute" },
                values: new object[] { "1 Beach Road", 700m, "Singapore", "info@raffles.com", "+6563371886", "Singapore", "A historic hotel that epitomizes the romance of the Far East.", "Raffles Hotel", 2, 3, 115, true, "189673", 5, "Standard, Deluxe, Suite", 1.2945, 103.8545 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes", "lat", "longitute" },
                values: new object[] { "31 Avenue George V", 950m, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Paris", "info@fourseasons.com", "+33149527000", "France", "Luxury accommodations with an Art Deco flair in Paris.", true, "Four Seasons Hotel George V", 2, 3, 244, true, "75008", 5, "Standard, Deluxe, Suite", 48.868600000000001, 2.3005 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes", "lat", "longitute" },
                values: new object[] { "Taj East Gate Road, Paktola, Tajganj", 550m, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Agra", "info@oberoihotels.com", "+915622231515", "India", "Luxury hotel with views of the Taj Mahal.", true, "The Oberoi Amarvilas", 2, 3, 102, true, "282001", 5, "Standard, Deluxe, Suite", 27.1739, 78.042100000000005 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "AveragePricePerNight", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "PostalCode", "Rating", "RoomTypes", "Wifi", "lat", "longitute" },
                values: new object[] { "48 Oriental Avenue", 700m, "Bangkok", "info@mandarinoriental.com", "+6626599000", "Thailand", "Historic luxury hotel on the banks of the Chao Phraya River.", true, "Mandarin Oriental, Bangkok", 2, 3, 331, "10500", 5, "Standard, Deluxe, Suite", true, 13.7204, 100.51479999999999 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "AveragePricePerNight", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes", "lat", "longitute" },
                values: new object[] { "10 Bayfront Ave", 450m, "Singapore", "info@marinabaysands.com", "+6566888888", "Singapore", "Futuristic hotel with an iconic infinity pool.", true, "Marina Bay Sands", 2, 3, 2561, true, "018956", 5, "Standard, Deluxe, Suite", 1.2834000000000001, 103.86069999999999 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "240f6805-0d22-4876-ac8f-59a5c6fd2710");

            migrationBuilder.DropColumn(
                name: "lat",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "longitute",
                table: "Hotels");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "f0d7a46b-515d-486d-a9fa-39503ee53c30", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "0c4bfc4a-7f48-49e8-ba3f-6b75b18e8d31", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOYZCTmRU7H6to5ehnKY8yefcMip5OsYEG9Znarr2tA6HW1RtFRjmZth/fs0afagCQ==", null, false, 0, null, "284c2fba-aede-4f70-b0c7-40c145dc9cf7", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfRooms", "PostalCode", "RoomTypes" },
                values: new object[] { "123 Beachfront Road", 300m, new TimeSpan(0, 14, 0, 0, 0), "Paradise City", "info@luxuryresort.com", "+1234567890", "Tropical Island", "Experience ultimate luxury and relaxation at our beachfront resort.", "Luxury Resort", 100, "54321", "Standard, Deluxe, Suite" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfRooms", "Pool", "PostalCode", "RoomTypes" },
                values: new object[] { "456 Alpine Drive", 200m, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Mountain Village", "info@mountainlodge.com", "+9876543210", "Alpine Wonderland", "Escape to the mountains and enjoy cozy accommodations and breathtaking views.", "Mountain Lodge", 50, false, "98765", "Standard, Chalet, Cabin" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfRooms", "PostalCode", "Rating", "RoomTypes" },
                values: new object[] { "789 Downtown Avenue", 250m, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Paradise City", "info@citycenterhotel.com", "+5432109876", "Urbania", "Stay in the heart of the city and explore all that Metropolis has to offer.", "City Center Hotel", 80, "12345", 2, "Standard, Executive, Suite" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "PostalCode", "Rating", "RoomTypes" },
                values: new object[] { "101 Seaside Boulevard", 280m, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Oceanfront Town", "info@coastalretreat.com", "+9876123450", "Seaside Haven", "Relax by the sea and enjoy stunning views at our coastal retreat.", false, "Coastal Retreat", 0, 0, 120, "13579", 4, "Standard, Ocean View, Beachfront Villa" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes", "Wifi" },
                values: new object[] { "789 Countryside Lane", 150m, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Ruralville", "info@ruralfarmstay.com", "+1357924680", "Countryland", "Experience farm life and unwind in the tranquility of the countryside.", false, "Rural Farmstay", 0, 0, 20, false, "24680", 3, "Farmhouse, Cottage", false });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Address", "AveragePricePerNight", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes" },
                values: new object[] { "321 Trendy Street", 180m, "Hipsterville", "info@urbanboutiquehotel.com", "+6789012345", "Trendyland", "Immerse yourself in the vibrant culture of Hipsterville at our trendy boutique hotel.", "Urban Boutique Hotel", 0, 0, 40, false, "86420", 4, "Standard, Loft, Penthouse" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes" },
                values: new object[] { "456 Heritage Lane", 170m, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Old Town", "info@historicinn.com", "+5432198765", "Nostalgia", "Step back in time and stay in a charming historic inn in the heart of Old Town.", false, "Historic Inn", 0, 0, 25, false, "97531", 3, "Classic Room, Suite" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Address", "AveragePricePerNight", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes" },
                values: new object[] { "789 Mountain Road", 220m, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Snowy Peaks", "info@skilodge.com", "+9876543210", "Winterland", "Hit the slopes and cozy up by the fire at our charming ski lodge.", false, "Ski Lodge", 0, 0, 60, false, "36984", 1, "Standard, Chalet" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Address", "AveragePricePerNight", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "PostalCode", "Rating", "RoomTypes", "Wifi" },
                values: new object[] { "321 Sand Dune Drive", 160m, "Sandy Valley", "info@desertoasis.com", "+1234567890", "Dunescape", "Experience the beauty of the desert and unwind in our luxurious oasis.", false, "Desert Oasis", 0, 0, 30, "75319", 3, "Standard Tent, Deluxe Tent", false });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Address", "AveragePricePerNight", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Pool", "PostalCode", "Rating", "RoomTypes" },
                values: new object[] { "147 Lakeside Avenue", 190m, "Lakeland", "info@lakefrontlodge.com", "+6789012345", "Lakelandia", "Escape to the serene beauty of the lake and relax at our charming lakefront lodge.", false, "Lakefront Lodge", 0, 0, 35, false, "58204", 2, "Standard, Lakeside Suite" });
        }
    }
}
