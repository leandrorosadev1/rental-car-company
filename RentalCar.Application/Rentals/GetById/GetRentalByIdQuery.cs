using MediatR;
using RentalCar.Domain.Rentals;

namespace RentalCar.Application.Rentals.GetById
{
    public record GetRentalByIdQuery(int Id) : IRequest<Rental>;
}
