using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Cars;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Cars.GetAllAvailable
{
    public class GetAllAvailableCarsQueryHandler : IRequestHandler<GetAllAvailableCarsQuery, List<AvailableCar>>
    {
        private readonly RentalCarDbContext _context;

        public GetAllAvailableCarsQueryHandler(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<List<AvailableCar>> Handle(GetAllAvailableCarsQuery query, CancellationToken cancellationToken)
        {
            if (query.FromDate.Date < DateTime.Today
                || query.ToDate.Date < DateTime.Today
                || query.ToDate.Date < query.FromDate.Date)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.VALIDATION_ERROR,
                    "INVALID_DATE_RANGE");
            }

            int skip = query.PageNumber * query.RowsPerPage;
            var cars = await _context.AvailableCars.FromSqlRaw(
                "exec GetAvailableCars {0}, {1}, {2}, {3}, {4}",
                query.FromDate,
                query.ToDate,
                query.CountryId,
                skip,
                query.RowsPerPage).ToListAsync();

            return cars;
        }
    }
}
