using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingimages5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomImage",
                value: "/Images/mountain_lodge.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomImage",
                value: "/Images/city_center_hotel.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomImage",
                value: "/Images/coastal_retreat.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomImage",
                value: "/Images/rural_farmstay.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomImage",
                value: "/Images/urban_boutique_hotel.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomImage",
                value: "/Images/historic_inn.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoomImage",
                value: "/Images/ski_lodge.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomImage",
                value: "rural_farmstay.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomImage",
                value: "urban_boutique_hotel.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomImage",
                value: "historic_inn.jpg");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoomImage",
                value: "ski_lodge.jpg");
        }
    }
}
