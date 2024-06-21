using MediatR;
using RentalCar.Domain.Cars;

namespace RentalCar.Application.CarBrands.GetAll
{
    public record GetAllCarBrandsQuery() : IRequest<List<CarBrand>>;
}
