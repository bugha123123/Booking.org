using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class adhawhdw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167ac8bc-463d-47ee-8b4f-0c379f1a777b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "591b135f-55f9-45ba-aff8-5a878bbd11d9", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "d178b1b9-5839-40c8-b970-9bdc6c85a714", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEINV2azK+I30XKrMPwx2i652QieGKdeb2dYB8kHs4QwZFYP+EnB1NPCVShwyVxEz7w==", null, false, 0, null, "0d1f532e-ee72-46ae-a473-b85e3c4c9663", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "591b135f-55f9-45ba-aff8-5a878bbd11d9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Points", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole", "tierLevels" },
                values: new object[] { "167ac8bc-463d-47ee-8b4f-0c379f1a777b", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "7f7e117a-a015-4a88-8c89-25cdcbc4f24a", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPRvKYjrknQXi1Kf1Zdk5PvohpeVFCdPBdYT3BmWNHSCqhaOfoQByyNk9mT1+Zjs9A==", null, false, 0, null, "f7e6dca9-f76e-4d14-9ada-60c50bdb4fff", false, "admin@example.com", "ADMIN", 0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                column: "Rating",
                value: 5);
        }
    }
}
