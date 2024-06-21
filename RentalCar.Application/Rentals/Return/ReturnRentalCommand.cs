using MediatR;

namespace RentalCar.Application.Rentals.Return
{
    public record ReturnRentalCommand(int Id) : IRequest;
}
