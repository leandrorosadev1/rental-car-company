using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Application.Common.Services;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Rentals;
using RentalCar.Domain.Users;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Rentals.Confirm
{
    public class ConfirmRentalCommandHandler : IRequestHandler<ConfirmRentalCommand, int>
    {
        private readonly RentalCarDbContext _context;
        private readonly CustomerUsersService _customerUsersService;
        private readonly CarsService _carsService;

        public ConfirmRentalCommandHandler(
            RentalCarDbContext context,
            CustomerUsersService customerUsersService,
            CarsService carsService)
        {
            _context = context;
            _customerUsersService = customerUsersService;
            _carsService = carsService;
        }

        public async Task<int> Handle(ConfirmRentalCommand command, CancellationToken cancellationToken)
        {
            var customerUser = await _customerUsersService.GetById(command.CustomerUserId);
            var car = await _carsService.GetById(command.CarId);

            var carCalendars = await GetCarCalendars(command.CarId, command.FromDate, command.ToDate, customerUser);

            var totalDays = CarCalendar.GetTotalDays(command.FromDate, command.ToDate);
            if (carCalendars.Count != totalDays)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.VALIDATION_ERROR,
                    "RANGE_NOT_AVAILABLE",
                    $"Range from {command.FromDate} to {command.ToDate} is not available for car with id {command.CarId}");
            }

            Rental rental;
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                foreach (var carCalendar in carCalendars)
                {
                    int lastVersion = carCalendar.Version;

                    int rowAffected = await _context.CarCalendar
                        .Where(cc => cc.Id == carCalendar.Id && cc.Version == lastVersion)
                        .ExecuteUpdateAsync(cc => cc
                            .SetProperty(c => c.Status, CarCalendarStatus.RESERVED)
                            .SetProperty(c => c.Version, lastVersion + 1)
                        );

                    if (rowAffected != 1)
                    {
                        await transaction.RollbackAsync();
                        throw new ApplicationLayerException(
                            ApplicationLayerExceptionType.VALIDATION_ERROR,
                            "DAY_NOT_AVAILABLE",
                            $"Day {carCalendar.CalendarDate} is not vailable for car with id {command.CarId}");
                    }
                }

                rental = new Rental(customerUser, car, command.FromDate.Date, command.ToDate.Date, car.DailyPrice);

                _context.Rentals.Add(rental);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }

            return rental.Id;
        }

        private async Task<List<CarCalendar>> GetCarCalendars(
            int carId,
            DateTime fromDate,
            DateTime toDate,
            CustomerUser customerUser)
        {
            DateTime now = DateTime.UtcNow;

            return await _context.CarCalendar
                .Where(cc => cc.Car.Id == carId
                    && cc.CalendarDate >= fromDate.Date
                    && cc.CalendarDate <= toDate.Date
                    && cc.Status == CarCalendarStatus.AVAILABLE
                    && cc.HoldByCustomerUser == customerUser
                    && cc.HoldUpToDate >= now)
                .ToListAsync();
        }
    }
}
