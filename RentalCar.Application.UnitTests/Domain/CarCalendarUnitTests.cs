using RentalCar.Application.UnitTests.Objects;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Common;

namespace RentalCar.Application.UnitTests.Domain
{
    public class CarCalendarUnitTests
    {
        [Fact]
        public async Task CarCalendar_GetTotalDays_Should_ReturnFiveDouble()
        {
            var fromDate = new DateTime(2024, 06, 21);
            var toDate = new DateTime(2024, 06, 25);

            var totalDays = CarCalendar.GetTotalDays(fromDate, toDate);

            Assert.Equal(5, totalDays);
            Assert.IsType<double>(totalDays);
        }

        [Fact]
        public async Task CarCalendar_GetTotalDays_Should_ThrowDomainLayerException_WhenFromDateIsGreaterThanToDate()
        {
            var fromDate = new DateTime(2024, 06, 25);
            var toDate = new DateTime(2024, 06, 21);

            Action act = () => CarCalendar.GetTotalDays(fromDate, toDate);

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_DATE_RANGE", exception.Title);
        }

        [Fact]
        public async Task CarCalendar_GetTotalDays_Should_ReturnOneDouble_WhenDatesAreEqual()
        {
            var fromDate = new DateTime(2024, 06, 21);
            var toDate = new DateTime(2024, 06, 21);

            var totalDays = CarCalendar.GetTotalDays(fromDate, toDate);

            Assert.Equal(1, totalDays);
            Assert.IsType<double>(totalDays);
        }

        [Fact]
        public async Task CarCalendar_SetAsAvailableFromReserved_Should_BeSuccess_WhenIsReserved()
        {
            var carCalendar = new CarCalendar(DateTime.Now, CarCalendarStatus.RESERVED);
            var previousVersion = carCalendar.Version;

            carCalendar.SetAsAvailableFromReserved();

            Assert.Equal(CarCalendarStatus.AVAILABLE, carCalendar.Status);
            Assert.Equal(previousVersion + 1, carCalendar.Version);
            Assert.Null(carCalendar.HoldByCustomerUser);
            Assert.Null(carCalendar.HoldUpToDate);
        }

        [Fact]
        public async Task CarCalendar_SetAsAvailableFromReserved_ThrowDomainLayerException_WhenIsNotReserved()
        {
            var carCalendar = new CarCalendar(DateTime.Now);
            var previousStatus = carCalendar.Status;
            var previousVersion = carCalendar.Version;
            var previousHoldBy = carCalendar.HoldByCustomerUser;
            var previousHoldUp = carCalendar.HoldUpToDate;

            Action act = () => carCalendar.SetAsAvailableFromReserved();

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_PREVIOUS_STATUS", exception.Title);
            Assert.Equal(previousStatus, carCalendar.Status);
            Assert.Equal(previousVersion, carCalendar.Version);
            Assert.Equal(previousHoldBy, carCalendar.HoldByCustomerUser);
            Assert.Equal(previousHoldUp, carCalendar.HoldUpToDate);
        }

        [Fact]
        public async Task CarCalendar_SetNewHold_BeSucess_WhenUserIsActiveAndUpToDateIsGreaterThanNowUtc()
        {
            var carCalendar = new CarCalendar(DateTime.Today.AddDays(10));
            var previousVersion = carCalendar.Version;
            var customerUser = CustomerUserObjectFactory.Create();
            var holdUpToDate = DateTime.UtcNow.AddMinutes(5);

            carCalendar.SetNewHold(customerUser, holdUpToDate);

            Assert.Equal(customerUser.Id, carCalendar.HoldByCustomerUser.Id);
            Assert.Equal(holdUpToDate, carCalendar.HoldUpToDate);
            Assert.Equal(previousVersion + 1, carCalendar.Version);
        }

        [Fact]
        public async Task CarCalendar_SetNewHold_ThrowDomainLayerException_WhenUserIsInactive()
        {
            var carCalendar = new CarCalendar(DateTime.Today.AddDays(10));
            var previousVersion = carCalendar.Version;
            var previousHoldBy = carCalendar.HoldByCustomerUser;
            var previousHoldUp = carCalendar.HoldUpToDate;

            var customerUser = CustomerUserObjectFactory.Create();
            customerUser.SetAsInactive();

            var holdUpToDate = DateTime.UtcNow.AddMinutes(5);

            Action act = () => carCalendar.SetNewHold(customerUser, holdUpToDate);

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("CUSTOMER_USER_NOT_ACTIVE", exception.Title);
            Assert.Equal(previousHoldBy, carCalendar.HoldByCustomerUser);
            Assert.Equal(previousHoldUp, carCalendar.HoldUpToDate);
            Assert.Equal(previousVersion, carCalendar.Version);
        }

        [Fact]
        public async Task CarCalendar_SetNewHold_ThrowDomainLayerException_WhenUpToDateIsLowerThanUtcNow()
        {
            var carCalendar = new CarCalendar(DateTime.Today.AddDays(10));
            var previousVersion = carCalendar.Version;
            var previousHoldBy = carCalendar.HoldByCustomerUser;
            var previousHoldUp = carCalendar.HoldUpToDate;

            var customerUser = CustomerUserObjectFactory.Create();

            var holdUpToDate = DateTime.UtcNow.AddMinutes(-5);

            Action act = () => carCalendar.SetNewHold(customerUser, holdUpToDate);

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_HOLD_DATE_VALUE", exception.Title);
            Assert.Equal(previousHoldBy, carCalendar.HoldByCustomerUser);
            Assert.Equal(previousHoldUp, carCalendar.HoldUpToDate);
            Assert.Equal(previousVersion, carCalendar.Version);
        }

        [Fact]
        public async Task CarCalendar_SetAsFinishedFromReserved_Should_BeSuccess_WhenIsReserved()
        {
            var carCalendar = new CarCalendar(DateTime.Now, CarCalendarStatus.RESERVED);
            var previousVersion = carCalendar.Version;

            carCalendar.SetAsFinishedFromReserved();

            Assert.Equal(CarCalendarStatus.FINISHED, carCalendar.Status);
            Assert.Equal(previousVersion + 1, carCalendar.Version);
        }

        [Fact]
        public async Task CarCalendar_SetAsFinishedFromReserved_ThrowDomainLayerException_WhenIsNotReserved()
        {
            var carCalendar = new CarCalendar(DateTime.Now);
            var previousStatus = carCalendar.Status;
            var previousVersion = carCalendar.Version;
            var previousHoldBy = carCalendar.HoldByCustomerUser;
            var previousHoldUp = carCalendar.HoldUpToDate;

            Action act = () => carCalendar.SetAsFinishedFromReserved();

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_PREVIOUS_STATUS", exception.Title);
            Assert.Equal(previousStatus, carCalendar.Status);
            Assert.Equal(previousVersion, carCalendar.Version);
        }
    }
}
