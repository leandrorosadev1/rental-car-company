using Microsoft.EntityFrameworkCore;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Common;
using RentalCar.Domain.Permissions;
using RentalCar.Domain.Rentals;
using RentalCar.Domain.Users;

namespace RentalCar.Infrastructure.Data.Seeders
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            DateTime now = DateTime.Today;

            #region CarBrand
            modelBuilder.Entity<CarBrand>().HasData(
                new CarBrand("Chevrolet")
                {
                    Id = 100,
                    CreatedDate = now,
                    ModifiedDate = now,
                },
                new CarBrand("Ford")
                {
                    Id = 101,
                    CreatedDate = now,
                    ModifiedDate = now,
                },
                new CarBrand("Volkswagen")
                {
                    Id = 102,
                    CreatedDate = now,
                    ModifiedDate = now,
                },
                new CarBrand("Renault")
                {
                    Id = 103,
                    CreatedDate = now,
                    ModifiedDate = now,
                },
                new CarBrand("Fiat")
                {
                    Id = 104,
                    CreatedDate = now,
                    ModifiedDate = now,
                }
            );
            #endregion

            #region Country
            modelBuilder.Entity<Country>().HasData(
                new Country("Argentina", 18)
                {
                    Id = 100,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new Country("Brasil", 16)
                {
                    Id = 101,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new Country("Chile", 21)
                {
                    Id = 102,
                    CreatedDate = now,
                    ModifiedDate = now
                }
            );
            #endregion

            #region PlatformRole
            modelBuilder.Entity<PlatformRole>().HasData(
                new PlatformRole("ADMIN")
                {
                    Id = 100,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new PlatformRole("CUSTOMER")
                {
                    Id = 101,
                    CreatedDate = now,
                    ModifiedDate = now
                }
            );
            #endregion

            #region PlatformPermission

            modelBuilder.Entity<PlatformPermission>().HasData(
                new PlatformPermission("VEHICLE_ADD", "Add new vehicle")
                {
                    Id = 100,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new PlatformPermission("VEHICLE_REMOVE", "Remove a vehicle")
                {
                    Id = 101,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new PlatformPermission("CUSTOMER_REMOVE", "Remove a customer")
                {
                    Id = 102,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new PlatformPermission("RENTAL_ADD", "Add new rental")
                {
                    Id = 103,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new PlatformPermission("RENTAL_CANCEL", "Cancel rental")
                {
                    Id = 104,
                    CreatedDate = now,
                    ModifiedDate = now
                },
                new PlatformPermission("RENTAL_RETURN", "Return rental")
                {
                    Id = 105,
                    CreatedDate = now,
                    ModifiedDate = now
                }
            );

            #endregion

            #region CustomerUser
            modelBuilder.Entity<CustomerUser>().HasData(
                new
                {
                    Id = 100,
                    IsActive = true,
                    IdCardNumber = "41737140",
                    DriverLicenseNumber = "abc123",
                    CreatedDate = now,
                    ModifiedDate = now,
                    Firstname = "Juan",
                    Lastname = "Perez",
                    BirthDate = new DateTime(1999, 04, 02),
                    CountryId = 100,
                    Email = "juanperez@example.com",
                    Password = "288A771EBF8EF6A3C7B1E2ECDD87DAC9CFEF02BE94724EEEC526D381DE11396D"
                }
            );
            #endregion

            #region CompanyUser
            modelBuilder.Entity<CompanyUser>().HasData(
                new
                {
                    Id = 100,
                    PlatformRoleId = 100,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Firstname = "Marta",
                    Lastname = "Martinez",
                    BirthDate = new DateTime(1999, 04, 02),
                    CountryId = 100,
                    Email = "martamartinez@example.com",
                    Password = "288A771EBF8EF6A3C7B1E2ECDD87DAC9CFEF02BE94724EEEC526D381DE11396D"
                }
            );
            #endregion

            #region Car
            modelBuilder.Entity<Car>().HasData(
                  new
                  {
                      Id = 100,
                      CarBrandId = 100,
                      NumberPlate = "key123",
                      IsActive = true,
                      DailyPrice = (float)100,
                      PlacedInCountryId = 100,
                      CreatedDate = now,
                      ModifiedDate = now
                  },
                  new
                  {
                      Id = 101,
                      CarBrandId = 101,
                      NumberPlate = "foo123",
                      IsActive = true,
                      DailyPrice = (float)250,
                      PlacedInCountryId = 100,
                      CreatedDate = now,
                      ModifiedDate = now
                  }
            );
            #endregion

            #region CarCalendar
            modelBuilder.Entity<CarCalendar>().HasData(
                new
                {
                    Id = 100,
                    CalendarDate = new DateTime(2024, 06, 24),
                    CarId = 100,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.RESERVED,
                    Version = 1
                },
                new
                {
                    Id = 101,
                    CalendarDate = new DateTime(2024, 06, 25),
                    CarId = 100,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.RESERVED,
                    Version = 1
                },
                new
                {
                    Id = 102,
                    CalendarDate = new DateTime(2024, 06, 26),
                    CarId = 100,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                },
                new
                {
                    Id = 103,
                    CalendarDate = new DateTime(2024, 06, 27),
                    CarId = 100,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                },
                new
                {
                    Id = 104,
                    CalendarDate = new DateTime(2024, 06, 28),
                    CarId = 100,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                },
                new
                {
                    Id = 105,
                    CalendarDate = new DateTime(2024, 06, 24),
                    CarId = 101,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                },
                new
                {
                    Id = 106,
                    CalendarDate = new DateTime(2024, 06, 25),
                    CarId = 101,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                },
                new
                {
                    Id = 107,
                    CalendarDate = new DateTime(2024, 06, 26),
                    CarId = 101,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                },
                new
                {
                    Id = 108,
                    CalendarDate = new DateTime(2024, 06, 27),
                    CarId = 101,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                },
                new
                {
                    Id = 109,
                    CalendarDate = new DateTime(2024, 06, 28),
                    CarId = 101,
                    CreatedDate = now,
                    ModifiedDate = now,
                    Status = CarCalendarStatus.AVAILABLE,
                    Version = 0
                }
            );
            #endregion

            #region Rental
            modelBuilder.Entity<Rental>().HasData(
                new
                {
                    Id = 100,
                    CustomerUserId = 100,
                    CarId = 100,
                    Status = RentalStatus.APPROVED,
                    CreatedDate = now,
                    ModifiedDate = now,
                    DailyPrice = (float)100,
                    FromDate = new DateTime(2024, 06, 24),
                    ToDate = new DateTime(2024, 06, 25),
                    TotalPrice = (float)200
                }
            );
            #endregion
        }
    }
}
