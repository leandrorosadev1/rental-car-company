using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Cars;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Rentals.Return
{
    public class ReturnRentalCommandHandler : IRequestHandler<ReturnRentalCommand>
    {
        private readonly RentalCarDbContext _context;

        public ReturnRentalCommandHandler(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ReturnRentalCommand command, CancellationToken cancellationToken)
        {
            var rental = await _context.Rentals
                 .Where(r => r.Id == command.Id)
                 .Include(r => r.Car)
                 .SingleOrDefaultAsync();

            if (rental == null)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.NOT_FOUND,
                    "RENTAL_NOT_FOUND",
                    $"Rental with id {command.Id} was not found");
            }

            rental.SetAsFinished();

            var carCalendars = await GetCarCalendars(rental.Car.Id, rental.FromDate, rental.ToDate);
            foreach (var carCalendar in carCalendars)
            {
                carCalendar.SetAsFinishedFromReserved();
            }

            await _context.SaveChangesAsync();
        }

        private async Task<List<CarCalendar>> GetCarCalendars(int carId, DateTime fromDate, DateTime toDate)
        {
            return await _context.CarCalendar
                .Where(cc => cc.Car.Id == carId
                    && cc.CalendarDate >= fromDate.Date
                    && cc.CalendarDate <= toDate.Date)
                .ToListAsync();
        }
    }
}
