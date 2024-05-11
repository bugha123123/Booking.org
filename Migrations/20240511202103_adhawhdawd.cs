using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class adhawhdawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7820f2f-0a73-40e4-a6b5-97e2cb7e6f33");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Supports",
                newName: "AddedBy");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "1676a73d-b7a9-4df9-8988-695558455696", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "a4f9d083-d5a3-4911-9c84-62f7a86335f2", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEG/L6AMqJknIBwgZhEP46UxtcxGktZqY+T7LixREF8i28QB6tRaJSEg0kKqqoazXaQ==", null, false, null, "6171ae19-7ffd-40c2-ac2a-dc54a0575ffc", false, "admin@example.com", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1676a73d-b7a9-4df9-8988-695558455696");

            migrationBuilder.RenameColumn(
                name: "AddedBy",
                table: "Supports",
                newName: "UserEmail");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "d7820f2f-0a73-40e4-a6b5-97e2cb7e6f33", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "cd6b272a-ff92-455d-8f6c-bbf54cc6a8b7", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEK7JM5wsDLLevl77tQ5cTMbPgKIFb+syiRpekcM7P21IjY0OOOrjdr/+U/WMUrlGXw==", null, false, null, "7686e5cb-8abe-400a-b999-7b90a78e6bca", false, "admin@example.com", "ADMIN" });
        }
    }
}
