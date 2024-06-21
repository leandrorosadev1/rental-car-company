using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Application.Common.Services;
using RentalCar.Domain.Rentals;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.CustomerUsers.Delete
{
    public class DeleteCustomerUserCommandHandler : IRequestHandler<DeleteCustomerUserCommand>
    {
        private readonly RentalCarDbContext _context;
        private readonly CustomerUsersService _customerUsersService;

        public DeleteCustomerUserCommandHandler(RentalCarDbContext context, CustomerUsersService customerUsersService)
        {
            _context = context;
            _customerUsersService = customerUsersService;
        }

        public async Task Handle(DeleteCustomerUserCommand command, CancellationToken cancellationToken)
        {
            var customerUser = await _customerUsersService.GetById(command.Id);

            var now = DateTime.Today;
            var hasPendingRentals = await _context.Rentals
                .AnyAsync(r => r.Customer == customerUser
                    && r.ToDate.Date >= now
                    && r.Status == RentalStatus.APPROVED);

            if (hasPendingRentals)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.VALIDATION_ERROR,
                    "PENDING_RENTALS",
                    $"Customer user with id {customerUser.Id} has in progress or pending rentals");
            }

            customerUser.SetAsInactive();
            await _context.SaveChangesAsync();
        }
    }
}
