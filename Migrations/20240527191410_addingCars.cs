using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "591b135f-55f9-45ba-aff8-5a878bbd11d9");

            migrationBuilder.CreateTable(
                name: "RentalCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DropoffDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalCars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "bce7a411-ed83-4a22-9a7c-7f0227b3fec0", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "d30dc85f-4723-4aea-a15e-9dc51965a4cb", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDb1sUvt2QX+iN25CMxc5ipu5kq0rj9gmGIeHLXClyLEP9dl8yx/kmFMJmqwrKQCyA==", null, false, 0, null, "f5984993-0329-4e94-b770-04e09956f414", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.InsertData(
                table: "RentalCars",
                columns: new[] { "Id", "DropoffDate", "Latitude", "Location", "Longitude", "Make", "Model", "PickupDate", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, null, 40.712800000000001, "New York, NY", -74.006, "Toyota", "Camry", null, 50m, 2020 },
                    { 2, null, 34.052199999999999, "Los Angeles, CA", -118.2437, "Honda", "Civic", null, 45m, 2019 },
                    { 3, null, 41.878100000000003, "Chicago, IL", -87.629800000000003, "Ford", "Mustang", null, 70m, 2018 },
                    { 4, null, 29.760400000000001, "Houston, TX", -95.369799999999998, "Chevrolet", "Malibu", null, 55m, 2021 },
                    { 5, null, 33.448399999999999, "Phoenix, AZ", -112.074, "Nissan", "Altima", null, 40m, 2017 },
                    { 6, null, 39.952599999999997, "Philadelphia, PA", -75.165199999999999, "BMW", "3 Series", null, 80m, 2020 },
                    { 7, null, 29.424099999999999, "San Antonio, TX", -98.493600000000001, "Mercedes-Benz", "C-Class", null, 85m, 2019 },
                    { 8, null, 32.715699999999998, "San Diego, CA", -117.1611, "Audi", "A4", null, 90m, 2021 },
                    { 9, null, 32.776699999999998, "Dallas, TX", -96.796999999999997, "Hyundai", "Sonata", null, 50m, 2018 },
                    { 10, null, 37.338200000000001, "San Jose, CA", -121.88630000000001, "Kia", "Optima", null, 45m, 2020 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalCars");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bce7a411-ed83-4a22-9a7c-7f0227b3fec0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "591b135f-55f9-45ba-aff8-5a878bbd11d9", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "d178b1b9-5839-40c8-b970-9bdc6c85a714", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEINV2azK+I30XKrMPwx2i652QieGKdeb2dYB8kHs4QwZFYP+EnB1NPCVShwyVxEz7w==", null, false, 0, null, "0d1f532e-ee72-46ae-a473-b85e3c4c9663", false, "admin@example.com", "ADMIN", 0 });
        }
    }
}
