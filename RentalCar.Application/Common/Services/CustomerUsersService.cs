using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Users;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Common.Services
{
    public class CustomerUsersService
    {
        private readonly RentalCarDbContext _context;

        public CustomerUsersService(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerUser> GetById(int id)
        {
            var customerUser = await _context.CustomerUsers
                .Where(u => u.Id == id && u.IsActive)
                .SingleOrDefaultAsync();

            if (customerUser == null)
            {
                throw new ApplicationLayerException(
                ApplicationLayerExceptionType.NOT_FOUND,
                    "CUSTOMER_USER_NOT_FOUND",
                    $"Customer user with id {id} was not found");
            }

            return customerUser;
        }
    }
}
