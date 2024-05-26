using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class adhawhd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81b2dd07-b9df-4bf5-855f-e5125f13a47b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "d5210c76-0685-4344-88fc-cf9a8a03d2a8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "8e911b99-27ac-4852-8f3b-49a5b9e469b7", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAK+VzWUEVaIzP2bhCONZ89Ozv22ZCWydND4nJ0S4cdhpXw3D4K4YOndzIyqtGcfmg==", null, false, 0, null, "670c3088-0602-42bd-a622-5dddbc7b982d", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                column: "To",
                value: " Mandarin Oriental Bangkok ");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                column: "To",
                value: "Marina Bay Sands");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5210c76-0685-4344-88fc-cf9a8a03d2a8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "81b2dd07-b9df-4bf5-855f-e5125f13a47b", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "871f44c8-6bbd-49c4-97ec-e7767cf4a5f4", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAECyml7jNMmHCuhcQX1BHKNI/Ck7Qy/iAeIM2GV63Md5PAJJUfmTEipjvtKNoD4YObg==", null, false, 0, null, "2b0d3f50-1227-4834-992f-186b20bd60fa", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                column: "To",
                value: "Las Vegas, Nevada (LAS Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                column: "To",
                value: "Orlando, Florida (MCO Airport)");
        }
    }
}
