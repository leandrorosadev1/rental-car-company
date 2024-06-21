using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Cars;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Cars.GetById
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Car>
    {
        private readonly RentalCarDbContext _context;

        public GetCarByIdQueryHandler(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _context.Cars
                .Where(c => c.Id == request.Id)
                .Include(c => c.Brand)
                .Include(c => c.PlacedInCountry)
                .Include(c => c.Calendar.Where(cal => cal.CalendarDate >= DateTime.UtcNow.Date
                    && cal.Status == CarCalendarStatus.AVAILABLE))
                .SingleOrDefaultAsync();

            if (car == null || !car.IsActive)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.NOT_FOUND,
                    "CAR_NOT_FOUND",
                    $"Car with id {request.Id} was not found");
            }

            return car;
        }
    }
}
