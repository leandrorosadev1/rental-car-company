using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Domain.Common;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Countries.GetAll
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, List<Country>>
    {
        private readonly RentalCarDbContext _context;

        public GetAllCountriesQueryHandler(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> Handle(GetAllCountriesQuery query, CancellationToken cancellationToken)
        {
            return await _context.Countries.OrderBy(c => c.Name).ToListAsync();
        }
    }
}
