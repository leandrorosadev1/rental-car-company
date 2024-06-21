using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Domain.Cars;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.CarBrands.GetAll
{
    public class GetAllCarBrandsQueryHandler : IRequestHandler<GetAllCarBrandsQuery, List<CarBrand>>
    {
        private readonly RentalCarDbContext _context;

        public GetAllCarBrandsQueryHandler(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarBrand>> Handle(GetAllCarBrandsQuery query, CancellationToken cancellationToken)
        {
            return await _context.CarBrands.OrderBy(c => c.Name).ToListAsync();
        }
    }
}
