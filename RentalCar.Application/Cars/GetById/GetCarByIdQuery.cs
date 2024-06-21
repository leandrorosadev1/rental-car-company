using MediatR;
using RentalCar.Domain.Cars;

namespace RentalCar.Application.Cars.GetById
{
    public record GetCarByIdQuery(
        int Id) : IRequest<Car>;
}
