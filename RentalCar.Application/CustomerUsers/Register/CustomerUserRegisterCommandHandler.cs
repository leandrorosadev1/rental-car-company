using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Application.Common.Interfaces.Authentication;
using RentalCar.Application.Common.Services;
using RentalCar.Domain.Common;
using RentalCar.Domain.Users;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.CustomerUsers.Register
{
    public class CustomerUserRegisterCommandHandler : IRequestHandler<CustomerUserRegisterCommand>
    {
        private readonly RentalCarDbContext _context;
        private readonly ISecurityProvider _securityProvider;
        private readonly CountriesService _countriesService;
        public CustomerUserRegisterCommandHandler(
            RentalCarDbContext context,
            ISecurityProvider securityProvider,
            CountriesService countriesService)
        {
            _context = context;
            _securityProvider = securityProvider;
            _countriesService = countriesService;
        }

        public async Task Handle(CustomerUserRegisterCommand command, CancellationToken cancellationToken)
        {
            string password;
            string email = await ValidateAndNormalizeEmail(command.Email);

            Country country = await _countriesService.GetCountryById(command.CountryId);

            try
            {
                password = _securityProvider.HashPassword(command.Password);
            }
            catch
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.INTERNAL_SERVER_ERROR,
                    "ERROR_HASHING_PASSWORD");
            }

            CustomerUser customerUser = new CustomerUser(
                command.Firstname,
                command.Lastname,
                command.BirthDate,
                country,
                email,
                password,
                command.IdCardNumber,
                command.DriverLicenseNumber);

            _context.CustomerUsers.Add(customerUser);
            await _context.SaveChangesAsync();
        }

        private async Task<string> ValidateAndNormalizeEmail(string email)
        {
            email = email.ToLower();

            bool emailAlreadyExists = await _context.CustomerUsers.AnyAsync(u => u.Email == email);

            if (emailAlreadyExists)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.VALIDATION_ERROR,
                    "USER_EMAIL_ALREADY_EXISTS",
                    $"User with email {email} already exists");
            }
            return email;
        }
    }
}
