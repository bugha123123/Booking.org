using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class adawdhawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "240f6805-0d22-4876-ac8f-59a5c6fd2710");

            migrationBuilder.AddColumn<double>(
                name: "FromLat",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FromLong",
                table: "Flights",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "81b2dd07-b9df-4bf5-855f-e5125f13a47b", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "871f44c8-6bbd-49c4-97ec-e7767cf4a5f4", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAECyml7jNMmHCuhcQX1BHKNI/Ck7Qy/iAeIM2GV63Md5PAJJUfmTEipjvtKNoD4YObg==", null, false, 0, null, "2b0d3f50-1227-4834-992f-186b20bd60fa", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "American Airlines (AA)", "Non-stop flight from New York City to Miami", "New York City (JFK Airport)", 40.644399999999997, -73.974000000000004, "Miami, Florida (MIA Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "United Airlines (UA)", "Non-stop flight from Los Angeles to Denver", "Los Angeles, California (LAX Airport)", 34.052199999999999, -118.2437, "Denver, Colorado (DEN Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "Delta Air Lines (DL)", "Non-stop flight from Chicago to Seattle", "Chicago, Illinois (ORD Airport)", 41.881900000000002, -87.898600000000002, "Seattle, Washington (SEA Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "American Airlines (AA)", "Non-stop flight from Dallas to Honolulu", "Dallas, Texas (DFW Airport)", 32.854700000000001, -97.092799999999997, "Honolulu, Hawaii (HNL Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "Southwest Airlines (WN)", "Non-stop flight from Washington D.C. to Atlanta", "Washington D.C. (DCA Airport)", 38.895099999999999, -77.036699999999996, "Atlanta, Georgia (ATL Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "United Airlines (UA)", "Non-stop flight from San Francisco to Austin", "San Francisco, California (SFO Airport)", 37.618899999999996, -122.3777, "Austin, Texas (AUS Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "Delta Air Lines (DL)", "Non-stop flight from Seattle to Boston", "Seattle, Washington (SEA Airport)", 47.448999999999998, -122.3019, "Boston, Massachusetts (BOS Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "Frontier Airlines (F9)", "Non-stop flight from Denver to Salt Lake City", "Denver, Colorado (DEN Airport)", 39.864699999999999, -104.67359999999999, "Salt Lake City, Utah (SLC Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "Spirit Airlines (NK)", "Non-stop flight from Miami to Las Vegas", "Miami, Florida (MIA Airport)", 25.761700000000001, -80.180599999999998, "Las Vegas, Nevada (LAS Airport)" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Airline", "Description", "From", "FromLat", "FromLong", "To" },
                values: new object[] { "Delta Air Lines (DL)", "Non-stop flight from Atlanta to Orlando", "Atlanta, Georgia (ATL Airport)", 33.636699999999998, -84.428100000000001, "Orlando, Florida (MCO Airport)" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81b2dd07-b9df-4bf5-855f-e5125f13a47b");

            migrationBuilder.DropColumn(
                name: "FromLat",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FromLong",
                table: "Flights");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "240f6805-0d22-4876-ac8f-59a5c6fd2710", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "e161f609-fa53-463a-ba24-ae5e7f9b8e4a", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKbqUNSFwH3blQbT8skShiJ3rWjvZqer7ZfOeSz6wDNzXy7QJiG41GiPoyg5DKfx6Q==", null, false, 0, null, "df1e4ea7-dd3d-4d4a-ba24-efbcb3da0a17", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline A", "Non-stop flight from City A to Paradise City", "City A", "Luxury Resort" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline B", "Non-stop flight from City C to Mountain Village", "City C", "Mountain Village" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline C", "Non-stop flight from City E to Paradise City", "City E", "Paradise City" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline D", "Non-stop flight from City G to Oceanfront Town", "City G", "Oceanfront Town" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline E", "Non-stop flight from City H to Ruralville", "City H", "Ruralville" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline F", "Non-stop flight from City I to Hipsterville", "City I", "Hipsterville" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline G", "Non-stop flight from City J to Old Town", "City J", "Old Town" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline H", "Non-stop flight from City K to Snowy Peaks", "City K", "Snowy Peaks" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline I", "Non-stop flight from City L to Sandy Valley", "City L", "Sandy Valley" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Airline", "Description", "From", "To" },
                values: new object[] { "Airline J", "Non-stop flight from City M to Lakeland", "City M", "Lakeland" });
        }
    }
}
