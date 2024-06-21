using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Cars;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Common.Services
{
    public class CarsService
    {
        private readonly RentalCarDbContext _context;

        public CarsService(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<Car> GetById(int id)
        {
            var car = await _context.Cars
                .Where(c => c.Id == id && c.IsActive)
                .Include(c => c.PlacedInCountry)
                .SingleOrDefaultAsync();

            if (car == null)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.NOT_FOUND,
                    "CAR_NOT_FOUND",
                    $"Car with id {id} was not found");
            }

            return car;
        }
    }
}
