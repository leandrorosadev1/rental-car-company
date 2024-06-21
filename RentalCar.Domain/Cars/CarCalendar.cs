using RentalCar.Domain.Common;
using RentalCar.Domain.Users;

namespace RentalCar.Domain.Cars
{
    public sealed class CarCalendar : BaseEntity
    {
        public static int MaxDaysRange => 100;
        public static int HoldMinutes => 5;

        #region Constructors
        public CarCalendar(DateTime date, CarCalendarStatus status = CarCalendarStatus.AVAILABLE)
        {
            CalendarDate = date;
            Version = 0;
            Status = status;
        }

        private CarCalendar()
        {

        }
        #endregion

        public DateTime CalendarDate { get; }
        public int Version { get; private set; }
        public CarCalendarStatus Status { get; private set; }
        public CustomerUser? HoldByCustomerUser { get; private set; }
        public DateTime? HoldUpToDate { get; private set; }
        public Car Car { get; set; }

        #region Methods
        public static double GetTotalDays(DateTime fromDate, DateTime toDate)
        {
            if (toDate.Date < fromDate.Date)
            {
                throw new DomainLayerException("INVALID_DATE_RANGE");
            }
            return (toDate - fromDate).TotalDays + 1;
        }

        public void SetAsAvailableFromReserved()
        {
            SetNewStatus(CarCalendarStatus.RESERVED, CarCalendarStatus.AVAILABLE);
            HoldByCustomerUser = null;
            HoldUpToDate = null;
        }

        public void SetAsFinishedFromReserved()
        {
            SetNewStatus(CarCalendarStatus.RESERVED, CarCalendarStatus.FINISHED);
        }

        private void SetNewStatus(CarCalendarStatus oldStatus, CarCalendarStatus newStatus)
        {
            if (Status != oldStatus)
            {
                throw new DomainLayerException("INVALID_PREVIOUS_STATUS");
            }
            Status = newStatus;
            Version++;
        }

        public void SetNewHold(CustomerUser customerUser, DateTime upToDate)
        {
            if (!customerUser.IsActive)
            {
                throw new DomainLayerException("CUSTOMER_USER_NOT_ACTIVE");
            }

            if (upToDate < DateTime.UtcNow)
            {
                throw new DomainLayerException("INVALID_HOLD_DATE_VALUE");
            }

            HoldByCustomerUser = customerUser;
            HoldUpToDate = upToDate;
            Version++;
        }
        #endregion
    }
}
