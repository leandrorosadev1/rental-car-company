using MediatR;
using RentalCar.Application.Common.DTOs;

namespace RentalCar.Application.CustomerUsers.Login
{
    public record CustomerUserLoginQuery(
        string Email,
        string Password) : IRequest<AuthenticationResult>;
}
