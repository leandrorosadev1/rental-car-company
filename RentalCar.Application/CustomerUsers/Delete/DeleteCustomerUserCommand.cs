using MediatR;

namespace RentalCar.Application.CustomerUsers.Delete
{
    public record DeleteCustomerUserCommand(int Id) : IRequest;
}
