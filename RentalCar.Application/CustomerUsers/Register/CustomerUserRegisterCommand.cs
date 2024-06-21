using MediatR;

namespace RentalCar.Application.CustomerUsers.Register
{
    public record CustomerUserRegisterCommand(
        string Firstname,
        string Lastname,
        DateTime BirthDate,
        int CountryId,
        string Email,
        string Password,
        string IdCardNumber,
        string DriverLicenseNumber) : IRequest;
}
