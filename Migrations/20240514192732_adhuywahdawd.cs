using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class adhuywahdawd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70ab6754-3d2e-4cb5-9c4c-6cf10565e8c8");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "d5d63206-d433-4469-80ca-29204093b3a8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "367a0c02-66e5-42eb-907a-74fb3dacd081", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENZ5iImOv/3moUB7nuMZO9qzFmhJOVXTdcGoh36nPBgY7avKqv3p/0NSjOozAVjwCA==", null, false, null, "78f8f17d-7548-493f-b197-0c9a43c94384", false, "admin@example.com", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_UserId",
                table: "Hotels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_UserId",
                table: "Hotels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_UserId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_UserId",
                table: "Hotels");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5d63206-d433-4469-80ca-29204093b3a8");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hotels");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "70ab6754-3d2e-4cb5-9c4c-6cf10565e8c8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "f83d39d5-4fda-4c94-96d5-e99d5f1bcf92", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKwERdgnDguxxRk+qSK/WZh4R7t6wGWgQz92XHlF9yQYjLs6PHVBHsvuYVoYADeLRw==", null, false, null, "bed1aa8b-2b70-44bd-b3a8-cd06475602f4", false, "admin@example.com", "ADMIN" });
        }
    }
}
