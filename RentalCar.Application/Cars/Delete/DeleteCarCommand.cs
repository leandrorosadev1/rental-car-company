using MediatR;

namespace RentalCar.Application.Cars.Delete
{
    public record DeleteCarCommand(int Id) : IRequest;
}
