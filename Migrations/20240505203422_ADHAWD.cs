using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class ADHAWD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "abcde569-1394-4c9a-8674-c311dc234782", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "208fd052-3988-4447-9858-9a3dc0408446", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJzJXfLTuOXNla1y1xEkRYW+tRBZCHr/QRA+O5VqSQXpU1ziu3n3VX1LRFoYmp5ZYg==", null, false, null, "5da22c66-375d-4cba-885f-03e95a6357b3", false, "admin@example.com", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "abcde569-1394-4c9a-8674-c311dc234782");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "1", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "47397d27-d305-466f-aa8f-5bd73cca8c9e", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAELazrztoSnOUxPESJgmeoYTboqD/0W3hi0+q+RYL/K/tUbuVxFEFLbZpYrE66C4Z2w==", null, false, null, "677bb2ac-a5cb-4ce6-920b-bb5293bb7951", false, "admin@example.com", "ADMIN" });
        }
    }
}
