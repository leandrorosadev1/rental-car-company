using MediatR;

namespace RentalCar.Application.Rentals.Start
{
    public class StartRentalCommand : IRequest
    {
        public int CarId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CustomerUserId { get; set; }
    }
}
