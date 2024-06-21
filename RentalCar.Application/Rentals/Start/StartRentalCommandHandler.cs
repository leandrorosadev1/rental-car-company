using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Application.Common.Services;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Rentals;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Rentals.Start
{
    public class StartRentalCommandHandler : IRequestHandler<StartRentalCommand>
    {
        private readonly RentalCarDbContext _context;
        private readonly CustomerUsersService _customersUsersService;
        private readonly CarsService _carsService;

        public StartRentalCommandHandler(
            RentalCarDbContext context,
            CustomerUsersService customersUsersService,
            CarsService carsService)
        {
            _context = context;
            _customersUsersService = customersUsersService;
            _carsService = carsService;
        }

        public async Task Handle(StartRentalCommand command, CancellationToken cancellationToken)
        {
            var customerUser = await _customersUsersService.GetById(command.CustomerUserId);

            var car = await _carsService.GetById(command.CarId);
            Rental.ValidateDriverAge(car, customerUser);

            var totalDays = CarCalendar.GetTotalDays(command.FromDate, command.ToDate);

            var carCalendars = await GetCarCalendars(car.Id, command.FromDate, command.ToDate);
            if (carCalendars.Count != totalDays)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.VALIDATION_ERROR,
                    "RANGE_NOT_AVAILABLE",
                    $"Range from {command.FromDate} to {command.ToDate} is not available for car with id {car.Id}");
            }

            DateTime holdUpTo = DateTime.UtcNow.AddMinutes(CarCalendar.HoldMinutes);
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                foreach (var carCalendar in carCalendars)
                {
                    int lastVersion = carCalendar.Version;
                    carCalendar.SetNewHold(customerUser, holdUpTo);

                    int rowAffected = await _context.CarCalendar
                        .Where(cc => cc.Id == carCalendar.Id && cc.Version == lastVersion)
                        .ExecuteUpdateAsync(cc => cc
                            .SetProperty(c => c.Version, carCalendar.Version)
                        );

                    if (rowAffected != 1)
                    {
                        await transaction.RollbackAsync();
                        throw new ApplicationLayerException(
                            ApplicationLayerExceptionType.VALIDATION_ERROR,
                            "DAY_NOT_AVAILABLE",
                            $"Day {carCalendar.CalendarDate} is not vailable for car with id {car.Id}");
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }

        private async Task<List<CarCalendar>> GetCarCalendars(int carId, DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Date < DateTime.Today || toDate.Date < DateTime.Today)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.VALIDATION_ERROR,
                    "INVALID_DATE_RANGE",
                    "Cannot create rentals in the past");
            }

            DateTime now = DateTime.UtcNow;
            return await _context.CarCalendar
                .Where(cc => cc.Car.Id == carId
                    && cc.CalendarDate >= fromDate.Date
                    && cc.CalendarDate <= toDate.Date
                    && cc.Status == CarCalendarStatus.AVAILABLE
                    && (!cc.HoldUpToDate.HasValue || now > cc.HoldUpToDate))
                .ToListAsync();
        }
    }
}
