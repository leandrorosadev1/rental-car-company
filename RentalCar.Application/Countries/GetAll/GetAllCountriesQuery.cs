using MediatR;
using RentalCar.Domain.Common;

namespace RentalCar.Application.Countries.GetAll
{
    public record GetAllCountriesQuery() : IRequest<List<Country>>;
}
