using Microsoft.EntityFrameworkCore;
using RentalCar.Domain.Permissions;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Common.Services
{
    public class PlatformRolesService
    {
        private RentalCarDbContext _context;

        public PlatformRolesService(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<PlatformRole> GetCustomerRoleWithPermissions()
        {
            return await _context.PlatformRoles
                .Where(r => r.Name == "CUSTOMER")
                .Include(r => r.Permissions)
                .SingleOrDefaultAsync();
        }
    }
}
