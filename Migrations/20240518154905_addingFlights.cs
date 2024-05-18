using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingFlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5d63206-d433-4469-80ca-29204093b3a8");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "411f9020-7cac-4ff0-9fc3-1b2b1762b1f4", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "b475d537-570c-4470-9a2d-18f22b844589", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAWEKl6bwcWHYUUxrH5WQopTDhYpuSuSehnyfmzCNwAMPIHlIjYcm3cfl+ypzufDTg==", null, false, null, "fdfe3769-f6a9-4552-bd2d-6e903a3f1a7b", false, "admin@example.com", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Airline", "ArrivalTime", "DepartureTime", "Description", "FlightNumber", "From", "HotelId", "Image", "Price", "Rating", "To" },
                values: new object[,]
                {
                    { 1, "Airline A", new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City A to Paradise City", "AA123", "City A", 1, "/Images/flight1.jpg", 150.00m, 4.5, "Paradise City" },
                    { 2, "Airline B", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City C to Mountain Village", "BB234", "City C", 2, "/Images/flight2.jpg", 200.00m, 4.0, "Mountain Village" },
                    { 3, "Airline C", new DateTime(2024, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City E to Paradise City", "CC345", "City E", 3, "/Images/flight3.jpg", 250.00m, 4.2999999999999998, "Paradise City" },
                    { 4, "Airline D", new DateTime(2024, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City G to Oceanfront Town", "DD456", "City G", 4, "/Images/flight4.jpg", 220.00m, 4.7000000000000002, "Oceanfront Town" },
                    { 5, "Airline E", new DateTime(2024, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City H to Ruralville", "EE567", "City H", 5, "/Images/flight5.jpg", 180.00m, 3.8999999999999999, "Ruralville" },
                    { 6, "Airline F", new DateTime(2024, 11, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City I to Hipsterville", "FF678", "City I", 6, "/Images/flight6.jpg", 190.00m, 4.0999999999999996, "Hipsterville" },
                    { 7, "Airline G", new DateTime(2024, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City J to Old Town", "GG789", "City J", 7, "/Images/flight7.jpg", 210.00m, 4.4000000000000004, "Old Town" },
                    { 8, "Airline H", new DateTime(2024, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City K to Snowy Peaks", "HH890", "City K", 8, "/Images/flight8.jpg", 230.00m, 4.2000000000000002, "Snowy Peaks" },
                    { 9, "Airline I", new DateTime(2024, 12, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City L to Sandy Valley", "II901", "City L", 9, "/Images/flight9.jpg", 240.00m, 4.5999999999999996, "Sandy Valley" },
                    { 10, "Airline J", new DateTime(2024, 12, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City M to Lakeland", "JJ012", "City M", 10, "/Images/flight10.jpg", 250.00m, 4.7999999999999998, "Lakeland" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_HotelId",
                table: "Flights",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "411f9020-7cac-4ff0-9fc3-1b2b1762b1f4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "d5d63206-d433-4469-80ca-29204093b3a8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "367a0c02-66e5-42eb-907a-74fb3dacd081", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENZ5iImOv/3moUB7nuMZO9qzFmhJOVXTdcGoh36nPBgY7avKqv3p/0NSjOozAVjwCA==", null, false, null, "78f8f17d-7548-493f-b197-0c9a43c94384", false, "admin@example.com", "ADMIN" });
        }
    }
}
