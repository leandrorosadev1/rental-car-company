﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalCar.Infrastructure.Data;

#nullable disable

namespace RentalCar.Infrastructure.Migrations
{
    [DbContext(typeof(RentalCarDbContext))]
    [Migration("20240619180129_20240619_1459")]
    partial class _20240619_1459
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlatformPermissionPlatformRole", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformRoleId")
                        .HasColumnType("int");

                    b.HasKey("PermissionsId", "PlatformRoleId");

                    b.HasIndex("PlatformRoleId");

                    b.ToTable("PlatformPermissionPlatformRole");
                });

            modelBuilder.Entity("RentalCar.Domain.Cars.AvailableCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DailyPrice")
                        .HasColumnType("real");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AvailableCars");
                });

            modelBuilder.Entity("RentalCar.Domain.Cars.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<float>("DailyPrice")
                        .HasColumnType("real");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("PlacedInCountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.HasIndex("NumberPlate")
                        .IsUnique();

                    b.HasIndex("PlacedInCountryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CarBrandId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DailyPrice = 100f,
                            IsActive = true,
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            NumberPlate = "key123",
                            PlacedInCountryId = 100
                        },
                        new
                        {
                            Id = 101,
                            CarBrandId = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DailyPrice = 250f,
                            IsActive = true,
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            NumberPlate = "foo123",
                            PlacedInCountryId = 100
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Cars.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarBrands");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Chevrolet"
                        },
                        new
                        {
                            Id = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 102,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 103,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 104,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Fiat"
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Cars.CarCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CalendarDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int?>("HoldByCustomerUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("HoldUpToDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Version")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("HoldByCustomerUserId");

                    b.HasIndex("CalendarDate", "CarId")
                        .IsUnique();

                    b.ToTable("CarCalendar");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CalendarDate = new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 1,
                            Version = 1
                        },
                        new
                        {
                            Id = 101,
                            CalendarDate = new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 1,
                            Version = 1
                        },
                        new
                        {
                            Id = 102,
                            CalendarDate = new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 103,
                            CalendarDate = new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 104,
                            CalendarDate = new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 105,
                            CalendarDate = new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 106,
                            CalendarDate = new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 107,
                            CalendarDate = new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 108,
                            CalendarDate = new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        },
                        new
                        {
                            Id = 109,
                            CalendarDate = new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CarId = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            Version = 0
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Common.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("DriverMinimumAge")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DriverMinimumAge = 18,
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DriverMinimumAge = 16,
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Brasil"
                        },
                        new
                        {
                            Id = 102,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DriverMinimumAge = 21,
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "Chile"
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Permissions.PlatformPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PlatformPermissions");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Add new vehicle",
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "VEHICLE_ADD"
                        },
                        new
                        {
                            Id = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Remove a vehicle",
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "VEHICLE_REMOVE"
                        },
                        new
                        {
                            Id = 102,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Remove a customer",
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "CUSTOMER_REMOVE"
                        },
                        new
                        {
                            Id = 103,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Add new rental",
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "RENTAL_ADD"
                        },
                        new
                        {
                            Id = 104,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Cancel rental",
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "RENTAL_CANCEL"
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Permissions.PlatformRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PlatformRoles");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "ADMIN"
                        },
                        new
                        {
                            Id = 101,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Name = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Rentals.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<int>("CustomerUserId")
                        .HasColumnType("int");

                    b.Property<float>("DailyPrice")
                        .HasColumnType("real");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerUserId");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            CarId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            CustomerUserId = 100,
                            DailyPrice = 100f,
                            FromDate = new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            ToDate = new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 200f
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Users.CompanyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("PlatformRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("PlatformRoleId");

                    b.HasIndex("Email", "Password");

                    b.ToTable("CompanyUsers");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            BirthDate = new DateTime(1999, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CountryId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Email = "martamartinez@example.com",
                            Firstname = "Marta",
                            Lastname = "Martinez",
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Password = "288A771EBF8EF6A3C7B1E2ECDD87DAC9CFEF02BE94724EEEC526D381DE11396D",
                            PlatformRoleId = 100
                        });
                });

            modelBuilder.Entity("RentalCar.Domain.Users.CustomerUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedUser")
                        .HasColumnType("int");

                    b.Property<string>("DriverLicenseNumber")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("IdCardNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedUser")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Email", "Password");

                    b.ToTable("CustomerUsers");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            BirthDate = new DateTime(1999, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CountryId = 100,
                            CreatedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DriverLicenseNumber = "abc123",
                            Email = "juanperez@example.com",
                            Firstname = "Juan",
                            IdCardNumber = "41737140",
                            IsActive = true,
                            Lastname = "Perez",
                            ModifiedDate = new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            Password = "288A771EBF8EF6A3C7B1E2ECDD87DAC9CFEF02BE94724EEEC526D381DE11396D"
                        });
                });

            modelBuilder.Entity("PlatformPermissionPlatformRole", b =>
                {
                    b.HasOne("RentalCar.Domain.Permissions.PlatformPermission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCar.Domain.Permissions.PlatformRole", null)
                        .WithMany()
                        .HasForeignKey("PlatformRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalCar.Domain.Cars.Car", b =>
                {
                    b.HasOne("RentalCar.Domain.Cars.CarBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCar.Domain.Common.Country", "PlacedInCountry")
                        .WithMany()
                        .HasForeignKey("PlacedInCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("PlacedInCountry");
                });

            modelBuilder.Entity("RentalCar.Domain.Cars.CarCalendar", b =>
                {
                    b.HasOne("RentalCar.Domain.Cars.Car", "Car")
                        .WithMany("Calendar")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCar.Domain.Users.CustomerUser", "HoldByCustomerUser")
                        .WithMany()
                        .HasForeignKey("HoldByCustomerUserId");

                    b.Navigation("Car");

                    b.Navigation("HoldByCustomerUser");
                });

            modelBuilder.Entity("RentalCar.Domain.Rentals.Rental", b =>
                {
                    b.HasOne("RentalCar.Domain.Cars.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCar.Domain.Users.CustomerUser", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RentalCar.Domain.Users.CompanyUser", b =>
                {
                    b.HasOne("RentalCar.Domain.Common.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalCar.Domain.Permissions.PlatformRole", "PlatformRole")
                        .WithMany()
                        .HasForeignKey("PlatformRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("PlatformRole");
                });

            modelBuilder.Entity("RentalCar.Domain.Users.CustomerUser", b =>
                {
                    b.HasOne("RentalCar.Domain.Common.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RentalCar.Domain.Cars.Car", b =>
                {
                    b.Navigation("Calendar");
                });
#pragma warning restore 612, 618
        }
    }
}
