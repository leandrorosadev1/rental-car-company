using MediatR;

namespace RentalCar.Application.Rentals.Confirm
{
    public class ConfirmRentalCommand : IRequest<int>
    {
        public int CarId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CustomerUserId { get; set; }
    }
}
