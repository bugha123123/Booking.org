using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingFlightBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66286696-117b-4102-b5ba-df23085607d5");

            migrationBuilder.CreateTable(
                name: "BookedFlights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    FlightsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedFlights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookedFlights_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookedFlights_Flights_FlightsId",
                        column: x => x.FlightsId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "7e2ddcc4-f832-4d92-b9ed-f6929af3d67d", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "4683e5ed-16de-4cc4-a49f-33aa12e3f1f9", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAELy80DXwg2/yr7DGAmgBI9uzB/SrGH3bjKK/gyUpi6YmOXt2zXczJF2OIVph2tO8Sg==", null, false, null, "f2376c75-b6e7-4f20-a6c2-1e8490d1bcbe", false, "admin@example.com", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_BookedFlights_FlightsId",
                table: "BookedFlights",
                column: "FlightsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedFlights_UserId",
                table: "BookedFlights",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedFlights");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e2ddcc4-f832-4d92-b9ed-f6929af3d67d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "66286696-117b-4102-b5ba-df23085607d5", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "9cf18818-09f3-489a-b27a-7a8ff6ec3baa", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENdyr/fi6xhyzhQ0uDKGREJGKjNS+rhj1/++bUC9FP5l4TQCfkI1m7qmAl5DsML9yQ==", null, false, null, "327572ef-b9e6-429a-bdcb-9931f5e664cb", false, "admin@example.com", "ADMIN" });
        }
    }
}
