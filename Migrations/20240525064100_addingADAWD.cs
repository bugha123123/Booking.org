using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingADAWD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1076469-fc78-4e60-aac3-fc41098ec5de");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "f0d7a46b-515d-486d-a9fa-39503ee53c30", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "0c4bfc4a-7f48-49e8-ba3f-6b75b18e8d31", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOYZCTmRU7H6to5ehnKY8yefcMip5OsYEG9Znarr2tA6HW1RtFRjmZth/fs0afagCQ==", null, false, 0, null, "284c2fba-aede-4f70-b0c7-40c145dc9cf7", false, "admin@example.com", "ADMIN", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0d7a46b-515d-486d-a9fa-39503ee53c30");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "d1076469-fc78-4e60-aac3-fc41098ec5de", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "cf234669-6763-45e3-a8c2-943371f523d5", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAhhK7mC3R09Hl1iS9c1L+F4uEZqwGVKmElGyqmX6Ff5HU+RFnPLHvT0hbbPrQVWLA==", null, false, null, "72383925-e2cc-43cb-82d6-d1801f63795c", false, "admin@example.com", "ADMIN", 0 });
        }
    }
}
