using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingLoyaltyProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c09b140-81e0-4e7a-a305-1a1e6165a4e8");

            migrationBuilder.AddColumn<int>(
                name: "tierLevels",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "d1076469-fc78-4e60-aac3-fc41098ec5de", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "cf234669-6763-45e3-a8c2-943371f523d5", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAhhK7mC3R09Hl1iS9c1L+F4uEZqwGVKmElGyqmX6Ff5HU+RFnPLHvT0hbbPrQVWLA==", null, false, null, "72383925-e2cc-43cb-82d6-d1801f63795c", false, "admin@example.com", "ADMIN", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d1076469-fc78-4e60-aac3-fc41098ec5de");

            migrationBuilder.DropColumn(
                name: "tierLevels",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "1c09b140-81e0-4e7a-a305-1a1e6165a4e8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "a177d6cc-5424-4ccb-b58c-8dd7621f9d2c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHAkbRnUw9LgY7YVjfVW5MUYNfS2us10IT3ycpIBB6m2bfbClHy9GFQiXrhX2STkFA==", null, false, null, "9e169cc2-5656-417c-bc6f-6b3ce4e3c279", false, "admin@example.com", "ADMIN" });
        }
    }
}
