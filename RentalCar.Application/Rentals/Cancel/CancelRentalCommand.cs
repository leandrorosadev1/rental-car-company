using MediatR;

namespace RentalCar.Application.Rentals.Cancel
{
    public record CancelRentalCommand(
        int Id,
        int? CustomerUserId) : IRequest;
}
