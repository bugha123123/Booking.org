using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingfavouritesz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4713d681-15cc-44f2-bb72-0e40a4a2d26c");

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FavoutiredHotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favourites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "70ab6754-3d2e-4cb5-9c4c-6cf10565e8c8", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "f83d39d5-4fda-4c94-96d5-e99d5f1bcf92", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKwERdgnDguxxRk+qSK/WZh4R7t6wGWgQz92XHlF9yQYjLs6PHVBHsvuYVoYADeLRw==", null, false, null, "bed1aa8b-2b70-44bd-b3a8-cd06475602f4", false, "admin@example.com", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_HotelId",
                table: "Favourites",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "70ab6754-3d2e-4cb5-9c4c-6cf10565e8c8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "4713d681-15cc-44f2-bb72-0e40a4a2d26c", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "d3f632d8-5c7c-4e95-a588-c4dd706ef88a", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENT3EacSm3rPs3AZoadTGLhA1vuNiBdiJ10ZurIv7JrsLVeAPK94N4EOtFYvHeHPrw==", null, false, null, "8b453f94-2951-4ca9-a6b8-072bd5dffcbe", false, "admin@example.com", "ADMIN" });
        }
    }
}
