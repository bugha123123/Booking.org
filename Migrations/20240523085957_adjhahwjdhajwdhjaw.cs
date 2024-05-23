using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class adjhahwjdhajwdhjaw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c4681c9-e915-4834-b36a-b76f820bd5b9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "1c09b140-81e0-4e7a-a305-1a1e6165a4e8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "a177d6cc-5424-4ccb-b58c-8dd7621f9d2c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHAkbRnUw9LgY7YVjfVW5MUYNfS2us10IT3ycpIBB6m2bfbClHy9GFQiXrhX2STkFA==", null, false, null, "9e169cc2-5656-417c-bc6f-6b3ce4e3c279", false, "admin@example.com", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c09b140-81e0-4e7a-a305-1a1e6165a4e8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "2c4681c9-e915-4834-b36a-b76f820bd5b9", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "ca932d80-16c5-4dc9-8ec6-82e1bbee703b", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPvcy7Tg4CCdJAA60G6Nkqr5ZQHSyF/XqaWfXREXFoqCyi5R442f0T1fLvAAMmrPfg==", null, false, null, "d1bc52a3-d3fd-4463-9db9-63e3c596c53a", false, "admin@example.com", "ADMIN" });
        }
    }
}
