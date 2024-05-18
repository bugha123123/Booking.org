using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingRela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "411f9020-7cac-4ff0-9fc3-1b2b1762b1f4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Flights",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "aed7c804-2268-46f9-a164-a057d78e8adc", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "b52a48c8-40be-4d65-9ba9-5973e227c467", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAECajX+xY2GDYpcBkWLgRaikrUjtBvfHDqZyj2lRvQnciuQ5NAn4Ss9pyaPQOQeAS3w==", null, false, null, "aa0218e0-6a7e-4363-a002-18657e6d6432", false, "admin@example.com", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "To", "UserId" },
                values: new object[] { "", null });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_UserId",
                table: "Flights",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_AspNetUsers_UserId",
                table: "Flights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_AspNetUsers_UserId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_UserId",
                table: "Flights");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aed7c804-2268-46f9-a164-a057d78e8adc");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Flights");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "411f9020-7cac-4ff0-9fc3-1b2b1762b1f4", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "b475d537-570c-4470-9a2d-18f22b844589", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAWEKl6bwcWHYUUxrH5WQopTDhYpuSuSehnyfmzCNwAMPIHlIjYcm3cfl+ypzufDTg==", null, false, null, "fdfe3769-f6a9-4552-bd2d-6e903a3f1a7b", false, "admin@example.com", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "To",
                value: "Paradise City");
        }
    }
}
