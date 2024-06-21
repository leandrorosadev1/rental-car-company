using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.DTOs;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Application.Common.Interfaces.Authentication;
using RentalCar.Application.Common.Services;
using RentalCar.Domain.Permissions;
using RentalCar.Domain.Users;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.CustomerUsers.Login
{
    public class CustomerUserLoginQueryHandler : IRequestHandler<CustomerUserLoginQuery, AuthenticationResult>
    {
        private readonly RentalCarDbContext _context;
        private readonly ISecurityProvider _securityProvider;
        private readonly PlatformRolesService _platformRolesService;
        public CustomerUserLoginQueryHandler(
            RentalCarDbContext context,
            ISecurityProvider securityProvider,
            PlatformRolesService platformRolesService)
        {
            _context = context;
            _securityProvider = securityProvider;
            _platformRolesService = platformRolesService;
        }

        public async Task<AuthenticationResult> Handle(CustomerUserLoginQuery query, CancellationToken cancellationToken)
        {
            string email = query.Email.ToLower();
            string password = _securityProvider.HashPassword(query.Password);

            CustomerUser? customerUser = await _context.CustomerUsers
                .Where(u => u.Email == email && u.Password == password)
                .SingleOrDefaultAsync();

            if (customerUser == null || !customerUser.IsActive)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.UNAUTHORIZED,
                    "INVALID_CREDENTIALS",
                    $"CustomerUser with email '{email}' and password '{query.Password}' does not exist");
            }

            PlatformRole customerRole = await _platformRolesService.GetCustomerRoleWithPermissions();

            var token = _securityProvider.GenerateToken(
                customerUser.Id,
                customerUser.Firstname,
                customerUser.Lastname,
                customerRole.Name,
                customerRole.Permissions.Select(p => p.Name).ToList());

            return new AuthenticationResult(customerUser, token);
        }
    }
}
