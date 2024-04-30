using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class addingimages2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomImage",
                value: "/Images/luxury_resort.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoomImage",
                value: "luxury_resort.jpg");
        }
    }
}
