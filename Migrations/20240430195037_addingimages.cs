using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomImage",
                value: "/mountain_lodge.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomImage",
                value: "/city_center_hotel.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomImage",
                value: "/coastal_retreat.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomImage",
                value: "mountain_lodge.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomImage",
                value: "city_center_hotel.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomImage",
                value: "coastal_retreat.jpg");
        }
    }
}
