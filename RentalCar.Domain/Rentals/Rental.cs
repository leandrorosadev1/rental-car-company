using RentalCar.Domain.Cars;
using RentalCar.Domain.Common;
using RentalCar.Domain.Users;

namespace RentalCar.Domain.Rentals
{
    public sealed class Rental : BaseEntity
    {
        #region Constructors
        public Rental(
            CustomerUser customer,
            Car car,
            DateTime fromDate,
            DateTime toDate,
            float dailyPrice)
        {
            ValidateDriverAge(car, customer);
            Customer = customer;
            Car = car;
            FromDate = fromDate;
            ToDate = toDate;
            DailyPrice = dailyPrice;
            SetTotalPrice();
            Status = RentalStatus.APPROVED;
        }

        private Rental()
        {

        }
        #endregion

        public CustomerUser Customer { get; }
        public Car Car { get; }
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }
        public float DailyPrice { get; }
        public float TotalPrice { get; private set; }
        public RentalStatus Status { get; private set; }

        #region Methods
        private void SetTotalPrice()
        {
            var totalDays = CarCalendar.GetTotalDays(FromDate, ToDate);
            TotalPrice = (float)totalDays * DailyPrice;
        }

        public void SetAsCanceled()
        {
            if (FromDate.Date <= DateTime.Today)
            {
                throw new DomainLayerException("INVALID_CANCELLATION_DATE");
            }

            if (Status == RentalStatus.CANCELED)
            {
                throw new DomainLayerException(
                   "RENTAL_ALREADY_CANCELLED",
                   $"Rental with id {Id} is already cancelled");
            }

            Status = RentalStatus.CANCELED;
        }

        public void SetAsFinished()
        {
            if (FromDate.Date > DateTime.Today)
            {
                throw new DomainLayerException("INVALID_FINISH_DATE");
            }

            if (Status == RentalStatus.FINISHED)
            {
                throw new DomainLayerException(
                   "RENTAL_ALREADY_FINISHED",
                   $"Rental with id {Id} is already finished");
            }

            Status = RentalStatus.FINISHED;
        }

        public static void ValidateDriverAge(Car car, CustomerUser customerUser)
        {
            if (car.PlacedInCountry.DriverMinimumAge > customerUser.CurrentAge)
            {
                throw new DomainLayerException(
                    "INVALID_AGE",
                    $"Customer user's age should be equal or greater than {car.PlacedInCountry.DriverMinimumAge}");
            }
        }
        #endregion
    }
}
