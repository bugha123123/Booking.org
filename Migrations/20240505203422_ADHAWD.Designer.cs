﻿// <auto-generated />
using System;
using Hotel.org.ApplicationDBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.org.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240505203422_ADHAWD")]
    partial class ADHAWD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.org.Models.BookedHotels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookedHotelImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("bookedHotels");
                });

            modelBuilder.Entity("Hotel.org.Models.Hotels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("AveragePricePerNight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Breakfast")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("CheckInTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("CheckOutTime")
                        .HasColumnType("time");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gym")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfAdults")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChildren")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<bool>("Parking")
                        .HasColumnType("bit");

                    b.Property<bool>("Pool")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("RoomImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Wifi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Beachfront Road",
                            AveragePricePerNight = 300m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 14, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 12, 0, 0, 0),
                            City = "Paradise City",
                            ContactEmail = "info@luxuryresort.com",
                            ContactPhone = "+1234567890",
                            Country = "Tropical Island",
                            Description = "Experience ultimate luxury and relaxation at our beachfront resort.",
                            Gym = true,
                            Name = "Luxury Resort",
                            NumberOfAdults = 2,
                            NumberOfChildren = 3,
                            NumberOfRooms = 100,
                            Parking = true,
                            Pool = true,
                            PostalCode = "54321",
                            Rating = 5,
                            RoomImage = "/Images/luxury_resort.jpg",
                            RoomTypes = "Standard, Deluxe, Suite",
                            Wifi = true
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Alpine Drive",
                            AveragePricePerNight = 200m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 15, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 11, 0, 0, 0),
                            City = "Mountain Village",
                            ContactEmail = "info@mountainlodge.com",
                            ContactPhone = "+9876543210",
                            Country = "Alpine Wonderland",
                            Description = "Escape to the mountains and enjoy cozy accommodations and breathtaking views.",
                            Gym = true,
                            Name = "Mountain Lodge",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 50,
                            Parking = true,
                            Pool = false,
                            PostalCode = "98765",
                            Rating = 4,
                            RoomImage = "/Images/mountain_lodge.jpg",
                            RoomTypes = "Standard, Chalet, Cabin",
                            Wifi = true
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Downtown Avenue",
                            AveragePricePerNight = 250m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 12, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 10, 0, 0, 0),
                            City = "Paradise City",
                            ContactEmail = "info@citycenterhotel.com",
                            ContactPhone = "+5432109876",
                            Country = "Urbania",
                            Description = "Stay in the heart of the city and explore all that Metropolis has to offer.",
                            Gym = true,
                            Name = "City Center Hotel",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 80,
                            Parking = true,
                            Pool = false,
                            PostalCode = "12345",
                            Rating = 4,
                            RoomImage = "/Images/city_center_hotel.jpg",
                            RoomTypes = "Standard, Executive, Suite",
                            Wifi = true
                        },
                        new
                        {
                            Id = 4,
                            Address = "101 Seaside Boulevard",
                            AveragePricePerNight = 280m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 13, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 11, 0, 0, 0),
                            City = "Oceanfront Town",
                            ContactEmail = "info@coastalretreat.com",
                            ContactPhone = "+9876123450",
                            Country = "Seaside Haven",
                            Description = "Relax by the sea and enjoy stunning views at our coastal retreat.",
                            Gym = false,
                            Name = "Coastal Retreat",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 120,
                            Parking = true,
                            Pool = true,
                            PostalCode = "13579",
                            Rating = 4,
                            RoomImage = "/Images/coastal_retreat.jpg",
                            RoomTypes = "Standard, Ocean View, Beachfront Villa",
                            Wifi = true
                        },
                        new
                        {
                            Id = 5,
                            Address = "789 Countryside Lane",
                            AveragePricePerNight = 150m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 16, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 10, 0, 0, 0),
                            City = "Ruralville",
                            ContactEmail = "info@ruralfarmstay.com",
                            ContactPhone = "+1357924680",
                            Country = "Countryland",
                            Description = "Experience farm life and unwind in the tranquility of the countryside.",
                            Gym = false,
                            Name = "Rural Farmstay",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 20,
                            Parking = true,
                            Pool = false,
                            PostalCode = "24680",
                            Rating = 3,
                            RoomImage = "/Images/rural_farmstay.jpg",
                            RoomTypes = "Farmhouse, Cottage",
                            Wifi = false
                        },
                        new
                        {
                            Id = 6,
                            Address = "321 Trendy Street",
                            AveragePricePerNight = 180m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 14, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 12, 0, 0, 0),
                            City = "Hipsterville",
                            ContactEmail = "info@urbanboutiquehotel.com",
                            ContactPhone = "+6789012345",
                            Country = "Trendyland",
                            Description = "Immerse yourself in the vibrant culture of Hipsterville at our trendy boutique hotel.",
                            Gym = true,
                            Name = "Urban Boutique Hotel",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 40,
                            Parking = true,
                            Pool = false,
                            PostalCode = "86420",
                            Rating = 4,
                            RoomImage = "/Images/urban_boutique_hotel.jpg",
                            RoomTypes = "Standard, Loft, Penthouse",
                            Wifi = true
                        },
                        new
                        {
                            Id = 7,
                            Address = "456 Heritage Lane",
                            AveragePricePerNight = 170m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 15, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 11, 0, 0, 0),
                            City = "Old Town",
                            ContactEmail = "info@historicinn.com",
                            ContactPhone = "+5432198765",
                            Country = "Nostalgia",
                            Description = "Step back in time and stay in a charming historic inn in the heart of Old Town.",
                            Gym = false,
                            Name = "Historic Inn",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 25,
                            Parking = true,
                            Pool = false,
                            PostalCode = "97531",
                            Rating = 4,
                            RoomImage = "/Images/historic_inn.jpg",
                            RoomTypes = "Classic Room, Suite",
                            Wifi = true
                        },
                        new
                        {
                            Id = 8,
                            Address = "789 Mountain Road",
                            AveragePricePerNight = 220m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 16, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 11, 0, 0, 0),
                            City = "Snowy Peaks",
                            ContactEmail = "info@skilodge.com",
                            ContactPhone = "+9876543210",
                            Country = "Winterland",
                            Description = "Hit the slopes and cozy up by the fire at our charming ski lodge.",
                            Gym = false,
                            Name = "Ski Lodge",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 60,
                            Parking = true,
                            Pool = false,
                            PostalCode = "36984",
                            Rating = 4,
                            RoomImage = "/Images/ski_lodge.jpg",
                            RoomTypes = "Standard, Chalet",
                            Wifi = true
                        },
                        new
                        {
                            Id = 9,
                            Address = "321 Sand Dune Drive",
                            AveragePricePerNight = 160m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 14, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 12, 0, 0, 0),
                            City = "Sandy Valley",
                            ContactEmail = "info@desertoasis.com",
                            ContactPhone = "+1234567890",
                            Country = "Dunescape",
                            Description = "Experience the beauty of the desert and unwind in our luxurious oasis.",
                            Gym = false,
                            Name = "Desert Oasis",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 30,
                            Parking = true,
                            Pool = true,
                            PostalCode = "75319",
                            Rating = 3,
                            RoomImage = "/Images/desert_oasis.jpg",
                            RoomTypes = "Standard Tent, Deluxe Tent",
                            Wifi = false
                        },
                        new
                        {
                            Id = 10,
                            Address = "147 Lakeside Avenue",
                            AveragePricePerNight = 190m,
                            Breakfast = true,
                            CheckInTime = new TimeSpan(0, 15, 0, 0, 0),
                            CheckOutTime = new TimeSpan(0, 11, 0, 0, 0),
                            City = "Lakeland",
                            ContactEmail = "info@lakefrontlodge.com",
                            ContactPhone = "+6789012345",
                            Country = "Lakelandia",
                            Description = "Escape to the serene beauty of the lake and relax at our charming lakefront lodge.",
                            Gym = false,
                            Name = "Lakefront Lodge",
                            NumberOfAdults = 0,
                            NumberOfChildren = 0,
                            NumberOfRooms = 35,
                            Parking = true,
                            Pool = false,
                            PostalCode = "58204",
                            Rating = 4,
                            RoomImage = "/Images/lakefront_lodge.jpg",
                            RoomTypes = "Standard, Lakeside Suite",
                            Wifi = true
                        });
                });

            modelBuilder.Entity("Hotel.org.Models.Reviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddedForHotel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("Hotel.org.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CardCV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CardExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileImageFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "abcde569-1394-4c9a-8674-c311dc234782",
                            AccessFailedCount = 0,
                            CardCV = "",
                            CardExpirationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CardNumber = "",
                            ConcurrencyStamp = "208fd052-3988-4447-9858-9a3dc0408446",
                            Email = "admin@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJzJXfLTuOXNla1y1xEkRYW+tRBZCHr/QRA+O5VqSQXpU1ziu3n3VX1LRFoYmp5ZYg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5da22c66-375d-4cba-885f-03e95a6357b3",
                            TwoFactorEnabled = false,
                            UserName = "admin@example.com",
                            UserRole = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Hotel.org.Models.BookedHotels", b =>
                {
                    b.HasOne("Hotel.org.Models.Hotels", "hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("hotel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Hotel.org.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Hotel.org.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.org.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Hotel.org.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
