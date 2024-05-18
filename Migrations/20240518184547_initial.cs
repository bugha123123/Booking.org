using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.org.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardCV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    Wifi = table.Column<bool>(type: "bit", nullable: false),
                    Parking = table.Column<bool>(type: "bit", nullable: false),
                    Breakfast = table.Column<bool>(type: "bit", nullable: false),
                    Gym = table.Column<bool>(type: "bit", nullable: false),
                    Pool = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfRooms = table.Column<int>(type: "int", nullable: false),
                    RoomTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    RoomImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AveragePricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AddedForHotel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedForFlight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookedHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookedHotelImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookedHotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookedHotels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookedHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CardCV", "CardExpirationDate", "CardNumber", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageFileName", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRole" },
                values: new object[] { "5796b4e0-69ce-4eda-9606-a4835f3377d2", 0, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "d7e9749a-708a-4ff3-b37f-8917036502ca", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEMxdEcxmSom8/8cB+Lox05y6jJH779QtIHRH56kJSkVmNnbaa70ciLLqH8SV2idLjA==", null, false, null, "e3435916-589a-4406-bef2-ecb0c1ef6acc", false, "admin@example.com", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "AveragePricePerNight", "Breakfast", "CheckInTime", "CheckOutTime", "City", "ContactEmail", "ContactPhone", "Country", "Description", "Gym", "Name", "NumberOfAdults", "NumberOfChildren", "NumberOfRooms", "Parking", "Pool", "PostalCode", "Rating", "RoomImage", "RoomTypes", "UserId", "Wifi" },
                values: new object[,]
                {
                    { 1, "123 Beachfront Road", 300m, true, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Paradise City", "info@luxuryresort.com", "+1234567890", "Tropical Island", "Experience ultimate luxury and relaxation at our beachfront resort.", true, "Luxury Resort", 2, 3, 100, true, true, "54321", 5, "/Images/luxury_resort.jpg", "Standard, Deluxe, Suite", null, true },
                    { 2, "456 Alpine Drive", 200m, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Mountain Village", "info@mountainlodge.com", "+9876543210", "Alpine Wonderland", "Escape to the mountains and enjoy cozy accommodations and breathtaking views.", true, "Mountain Lodge", 0, 0, 50, true, false, "98765", 5, "/Images/mountain_lodge.jpg", "Standard, Chalet, Cabin", null, true },
                    { 3, "789 Downtown Avenue", 250m, true, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Paradise City", "info@citycenterhotel.com", "+5432109876", "Urbania", "Stay in the heart of the city and explore all that Metropolis has to offer.", true, "City Center Hotel", 0, 0, 80, true, false, "12345", 2, "/Images/city_center_hotel.jpg", "Standard, Executive, Suite", null, true },
                    { 4, "101 Seaside Boulevard", 280m, true, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Oceanfront Town", "info@coastalretreat.com", "+9876123450", "Seaside Haven", "Relax by the sea and enjoy stunning views at our coastal retreat.", false, "Coastal Retreat", 0, 0, 120, true, true, "13579", 4, "/Images/coastal_retreat.jpg", "Standard, Ocean View, Beachfront Villa", null, true },
                    { 5, "789 Countryside Lane", 150m, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Ruralville", "info@ruralfarmstay.com", "+1357924680", "Countryland", "Experience farm life and unwind in the tranquility of the countryside.", false, "Rural Farmstay", 0, 0, 20, true, false, "24680", 3, "/Images/rural_farmstay.jpg", "Farmhouse, Cottage", null, false },
                    { 6, "321 Trendy Street", 180m, true, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Hipsterville", "info@urbanboutiquehotel.com", "+6789012345", "Trendyland", "Immerse yourself in the vibrant culture of Hipsterville at our trendy boutique hotel.", true, "Urban Boutique Hotel", 0, 0, 40, true, false, "86420", 4, "/Images/urban_boutique_hotel.jpg", "Standard, Loft, Penthouse", null, true },
                    { 7, "456 Heritage Lane", 170m, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Old Town", "info@historicinn.com", "+5432198765", "Nostalgia", "Step back in time and stay in a charming historic inn in the heart of Old Town.", false, "Historic Inn", 0, 0, 25, true, false, "97531", 3, "/Images/historic_inn.jpg", "Classic Room, Suite", null, true },
                    { 8, "789 Mountain Road", 220m, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Snowy Peaks", "info@skilodge.com", "+9876543210", "Winterland", "Hit the slopes and cozy up by the fire at our charming ski lodge.", false, "Ski Lodge", 0, 0, 60, true, false, "36984", 1, "/Images/ski_lodge.jpg", "Standard, Chalet", null, true },
                    { 9, "321 Sand Dune Drive", 160m, true, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Sandy Valley", "info@desertoasis.com", "+1234567890", "Dunescape", "Experience the beauty of the desert and unwind in our luxurious oasis.", false, "Desert Oasis", 0, 0, 30, true, true, "75319", 3, "/Images/desert_oasis.jpg", "Standard Tent, Deluxe Tent", null, false },
                    { 10, "147 Lakeside Avenue", 190m, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Lakeland", "info@lakefrontlodge.com", "+6789012345", "Lakelandia", "Escape to the serene beauty of the lake and relax at our charming lakefront lodge.", false, "Lakefront Lodge", 0, 0, 35, true, false, "58204", 2, "/Images/lakefront_lodge.jpg", "Standard, Lakeside Suite", null, true }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "Airline", "ArrivalTime", "DepartureTime", "Description", "FlightNumber", "From", "HotelId", "Image", "Price", "Rating", "To", "UserId" },
                values: new object[,]
                {
                    { 1, "Airline A", new DateTime(2024, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City A to Paradise City", "AA123", "City A", 1, "/Images/flight1.jpg", 150.00m, 4.5, "", null },
                    { 2, "Airline B", new DateTime(2024, 7, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City C to Mountain Village", "BB234", "City C", 2, "/Images/flight2.jpg", 200.00m, 4.0, "Mountain Village", null },
                    { 3, "Airline C", new DateTime(2024, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City E to Paradise City", "CC345", "City E", 3, "/Images/flight3.jpg", 250.00m, 4.2999999999999998, "Paradise City", null },
                    { 4, "Airline D", new DateTime(2024, 9, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City G to Oceanfront Town", "DD456", "City G", 4, "/Images/flight4.jpg", 220.00m, 4.7000000000000002, "Oceanfront Town", null },
                    { 5, "Airline E", new DateTime(2024, 10, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City H to Ruralville", "EE567", "City H", 5, "/Images/flight5.jpg", 180.00m, 3.8999999999999999, "Ruralville", null },
                    { 6, "Airline F", new DateTime(2024, 11, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City I to Hipsterville", "FF678", "City I", 6, "/Images/flight6.jpg", 190.00m, 4.0999999999999996, "Hipsterville", null },
                    { 7, "Airline G", new DateTime(2024, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City J to Old Town", "GG789", "City J", 7, "/Images/flight7.jpg", 210.00m, 4.4000000000000004, "Old Town", null },
                    { 8, "Airline H", new DateTime(2024, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City K to Snowy Peaks", "HH890", "City K", 8, "/Images/flight8.jpg", 230.00m, 4.2000000000000002, "Snowy Peaks", null },
                    { 9, "Airline I", new DateTime(2024, 12, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City L to Sandy Valley", "II901", "City L", 9, "/Images/flight9.jpg", 240.00m, 4.5999999999999996, "Sandy Valley", null },
                    { 10, "Airline J", new DateTime(2024, 12, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), "Non-stop flight from City M to Lakeland", "JJ012", "City M", 10, "/Images/flight10.jpg", 250.00m, 4.7999999999999998, "Lakeland", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_bookedHotels_HotelId",
                table: "bookedHotels",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_bookedHotels_UserId",
                table: "bookedHotels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_HotelId",
                table: "Favourites",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId",
                table: "Favourites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_HotelId",
                table: "Flights",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_UserId",
                table: "Flights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_UserId",
                table: "Hotels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supports_UserId",
                table: "Supports",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "bookedHotels");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
