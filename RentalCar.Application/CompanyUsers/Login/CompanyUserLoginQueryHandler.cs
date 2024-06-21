using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.DTOs;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Application.Common.Interfaces.Authentication;
using RentalCar.Domain.Users;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.CompanyUsers.Login
{
    public class CompanyUserLoginQueryHandler : IRequestHandler<CompanyUserLoginQuery, AuthenticationResult>
    {
        private readonly RentalCarDbContext _context;
        private readonly ISecurityProvider _securityProvider;
        public CompanyUserLoginQueryHandler(
            RentalCarDbContext context,
            ISecurityProvider securityProvider)
        {
            _context = context;
            _securityProvider = securityProvider;
        }

        public async Task<AuthenticationResult> Handle(CompanyUserLoginQuery query, CancellationToken cancellationToken)
        {
            string email = query.Email.ToLower();
            string password = _securityProvider.HashPassword(query.Password);

            CompanyUser? companyUser = await _context.CompanyUsers
                .Where(u => u.Email == email && u.Password == password)
                .Include(u => u.PlatformRole.Permissions)
                .SingleOrDefaultAsync();

            if (companyUser == null)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.UNAUTHORIZED,
                    "INVALID_CREDENTIALS",
                    $"CompanyUser with email '{email}' and password '{query.Password}' does not exist");
            }

            var token = _securityProvider.GenerateToken(
                companyUser.Id,
                companyUser.Firstname,
                companyUser.Lastname,
                companyUser.PlatformRole.Name,
                companyUser.PlatformRole.Permissions.Select(p => p.Name).ToList());

            return new AuthenticationResult(companyUser, token);
        }
    }
}
