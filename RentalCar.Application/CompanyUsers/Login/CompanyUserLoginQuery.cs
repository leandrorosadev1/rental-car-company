using MediatR;
using RentalCar.Application.Common.DTOs;

namespace RentalCar.Application.CompanyUsers.Login
{
    public record CompanyUserLoginQuery(
        string Email,
        string Password) : IRequest<AuthenticationResult>;
}
