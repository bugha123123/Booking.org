using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingJDKAJHKWDWAD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5210c76-0685-4344-88fc-cf9a8a03d2a8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "167ac8bc-463d-47ee-8b4f-0c379f1a777b", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "7f7e117a-a015-4a88-8c89-25cdcbc4f24a", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPRvKYjrknQXi1Kf1Zdk5PvohpeVFCdPBdYT3BmWNHSCqhaOfoQByyNk9mT1+Zjs9A==", null, false, 0, null, "f7e6dca9-f76e-4d14-9ada-60c50bdb4fff", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "To",
                value: "The Ritz-Carlton, Tokyo");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "To",
                value: "Hotel de Paris Monte-Carlo");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                column: "To",
                value: "The Plaza Hotel");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                column: "To",
                value: "Burj Al Arab");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                column: "To",
                value: "The Savoy Hotel");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                column: "To",
                value: "Raffles Hotel");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                column: "To",
                value: "Four Seasons Hotel George V");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                column: "To",
                value: "The Oberoi Amarvilas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167ac8bc-463d-47ee-8b4f-0c379f1a777b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "d5210c76-0685-4344-88fc-cf9a8a03d2a8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "8e911b99-27ac-4852-8f3b-49a5b9e469b7", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAK+VzWUEVaIzP2bhCONZ89Ozv22ZCWydND4nJ0S4cdhpXw3D4K4YOndzIyqtGcfmg==", null, false, 0, null, "670c3088-0602-42bd-a622-5dddbc7b982d", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "To",
                value: "Miami, Florida (MIA Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "To",
                value: "Denver, Colorado (DEN Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                column: "To",
                value: "Seattle, Washington (SEA Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                column: "To",
                value: "Honolulu, Hawaii (HNL Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                column: "To",
                value: "Atlanta, Georgia (ATL Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                column: "To",
                value: "Austin, Texas (AUS Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                column: "To",
                value: "Boston, Massachusetts (BOS Airport)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                column: "To",
                value: "Salt Lake City, Utah (SLC Airport)");
        }
    }
}
