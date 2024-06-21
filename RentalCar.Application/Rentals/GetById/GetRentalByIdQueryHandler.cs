using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Rentals;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Rentals.GetById
{
    public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, Rental>
    {
        private readonly RentalCarDbContext _context;

        public GetRentalByIdQueryHandler(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<Rental> Handle(GetRentalByIdQuery query, CancellationToken cancellationToken)
        {
            var rental = await _context.Rentals
                .Where(r => r.Id == query.Id)
                .Include(r => r.Car)
                .Include(r => r.Customer)
                .SingleOrDefaultAsync();

            if (rental == null)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.NOT_FOUND,
                    "RENTAL_NOT_FOUND",
                    $"Rental with id {query.Id} was not found");
            }

            return rental;
        }
    }
}
