using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class aduhawhdawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserRole",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "1", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "47397d27-d305-466f-aa8f-5bd73cca8c9e", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAELazrztoSnOUxPESJgmeoYTboqD/0W3hi0+q+RYL/K/tUbuVxFEFLbZpYrE66C4Z2w==", null, false, null, "677bb2ac-a5cb-4ce6-920b-bb5293bb7951", false, "admin@example.com", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "AspNetUsers");
        }
    }
}
