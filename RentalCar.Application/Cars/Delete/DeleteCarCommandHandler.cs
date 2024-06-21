using MediatR;
using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Cars.Delete
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly RentalCarDbContext _context;

        public DeleteCarCommandHandler(RentalCarDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCarCommand command, CancellationToken cancellationToken)
        {
            var car = await _context.Cars.Where(c => c.Id == command.Id).SingleOrDefaultAsync();

            if (car == null)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.NOT_FOUND,
                    "CAR_NOT_FOUND",
                    $"Car with id {command.Id} was not found");
            }

            car.SetAsInactive();
            await _context.SaveChangesAsync();
        }
    }
}
