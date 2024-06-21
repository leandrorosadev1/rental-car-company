using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Application.Common.Services;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Common;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Cars.Create
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
    {
        private readonly RentalCarDbContext _context;
        private readonly CountriesService _countriesService;
        public CreateCarCommandHandler(RentalCarDbContext context, CountriesService countriesService)
        {
            _context = context;
            _countriesService = countriesService;
        }

        public async Task<int> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            CarBrand carBrand = await GetCarBrand(command.BrandId);
            string numberPlate = await ValidateAndNormalizeNumberPlate(command.NumberPlate);
            Country country = await _countriesService.GetCountryById(command.PlacedInCountryId);

            Car car = new Car(carBrand, numberPlate, command.DailyPrice, country);

            CarCalendarDateRange dateRange = GetDateRange(
                command.UseDefaultCalendar,
                command.AvailableFromDate,
                command.AvailableToDate);

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Cars.Add(car);
                    await _context.SaveChangesAsync();

                    await _context.Database.ExecuteSqlRawAsync(
                            "CreateCarCalendarFromDateRange @carId, @startDate, @endDate, @userId",
                            new SqlParameter("@carId", car.Id),
                            new SqlParameter("@startDate", dateRange.FromDate),
                            new SqlParameter("@endDate", dateRange.ToDate),
                            new SqlParameter("@userId", car.CreatedUser));

                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw new ApplicationLayerException(
                        ApplicationLayerExceptionType.INTERNAL_SERVER_ERROR,
                        "ERROR_CREATING_CAR");
                }
            }

            return car.Id;
        }

        private async Task<CarBrand> GetCarBrand(int brandId)
        {
            CarBrand carBrand = await _context.CarBrands.Where(cb => cb.Id == brandId).SingleOrDefaultAsync();
            if (carBrand == null)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.NOT_FOUND,
                    "CAR_BRAND_NOT_FOUND",
                    $"CarBrand with id {brandId} was not found");
            }

            return carBrand;
        }

        private async Task<string> ValidateAndNormalizeNumberPlate(string numberPlate)
        {
            numberPlate = numberPlate.ToLower();

            bool isRegisterd = await _context.Cars.AnyAsync(x => x.NumberPlate == numberPlate);
            if (isRegisterd)
            {
                throw new ApplicationLayerException(
                   ApplicationLayerExceptionType.VALIDATION_ERROR,
                   "NUMBER_PLATE_ALREADY_EXISTS",
                   $"Car with number plate {numberPlate} already exists");
            }

            return numberPlate;
        }

        private void ValidateAvailabilityRange(DateTime fromDate, DateTime toDate)
        {
            if (toDate.Date < fromDate.Date)
            {
                throw new ApplicationLayerException(
                   ApplicationLayerExceptionType.VALIDATION_ERROR,
                   "INVALID_DATE_RANGE",
                   $"For car calendar ToDate should be greater than FromDate");
            }

            if (fromDate.Date < DateTime.Today)
            {
                throw new ApplicationLayerException(
                   ApplicationLayerExceptionType.VALIDATION_ERROR,
                   "INVALID_DATE_RANGE",
                   $"For car calendar FromDate should be greater than today");
            }

            if ((toDate - fromDate).TotalDays > CarCalendar.MaxDaysRange)
            {
                throw new ApplicationLayerException(
                   ApplicationLayerExceptionType.VALIDATION_ERROR,
                   "INVALID_DATE_RANGE",
                   $"For car calendar max range should be equal or lower than {CarCalendar.MaxDaysRange} days");
            }
        }

        private CarCalendarDateRange GetDateRange(bool useDefaultCalendar, DateTime? availableFromDate, DateTime? availableToDate)
        {
            DateTime availableFrom = DateTime.UtcNow.Date;
            DateTime availableTo = availableFrom;
            if (useDefaultCalendar)
            {
                availableTo = availableFrom.AddDays(Car.DefaultAvailabilityDays).Date;
            }
            else if (!availableFromDate.HasValue || !availableToDate.HasValue)
            {
                throw new ApplicationLayerException(
                   ApplicationLayerExceptionType.VALIDATION_ERROR,
                   "INVALID_DATE_RANGE",
                   $"For car calendar range should be defined if default calendar setting is not used ");
            }
            else
            {
                availableFrom = availableFromDate.Value.Date;
                availableTo = availableToDate.Value.Date;
                ValidateAvailabilityRange(availableFrom, availableTo);
            }

            return new CarCalendarDateRange(availableFrom, availableTo);
        }
    }
}
