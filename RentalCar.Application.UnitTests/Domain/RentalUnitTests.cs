using RentalCar.Application.UnitTests.Objects;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Common;
using RentalCar.Domain.Rentals;

namespace RentalCar.Application.UnitTests.Domain
{
    public class RentalUnitTests
    {
        [Fact]
        public async Task Rental_SetTotalPrice_Should_BeCalledOnConstructor_Success()
        {
            var year = DateTime.Now.AddYears(1).Year;
            var fromDate = new DateTime(year, 1, 1);
            var toDate = new DateTime(year, 1, 10);
            var rental = RentalObjectFactory.Create(fromDate, toDate);

            Assert.NotEqual(default(int), rental.TotalPrice);
            Assert.Equal(CarCalendar.GetTotalDays(fromDate, toDate) * rental.DailyPrice, rental.TotalPrice);
        }

        [Fact]
        public async Task Rental_ValidateDriverAge_Should_BeCalledOnConstructor_Success_WhenDriverAgeIsGreaterOrEqualThanCountryRule()
        {
            var year = DateTime.Now.AddYears(1).Year;
            var fromDate = new DateTime(year, 1, 1);
            var toDate = new DateTime(year, 1, 10);

            Action act = () => RentalObjectFactory.Create(fromDate, toDate);

            var exception = Record.Exception(act);

            Assert.Null(exception);
        }

        [Fact]
        public async Task Rental_ValidateDriverAge_Should_BeCalledOnConstructor_ThrowDomainLayerException_WhenDriverAgeIsLowerThanCountryRule()
        {
            var year = DateTime.Now.AddYears(1).Year;
            var fromDate = new DateTime(year, 1, 1);
            var toDate = new DateTime(year, 1, 10);

            Action act = () => RentalObjectFactory.Create(fromDate, toDate, 200);

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_AGE", exception.Title);
        }

        [Fact]
        public async Task Rental_SetAsCanceled_Should_BeSuccess_WhenRentalTimeNotStartedAndIsNotCanceled()
        {
            var year = DateTime.Now.AddYears(1).Year;
            var fromDate = new DateTime(year, 1, 1);
            var toDate = new DateTime(year, 1, 10);

            var rental = RentalObjectFactory.Create(fromDate, toDate);
            var previousStatus = rental.Status;

            rental.SetAsCanceled();

            Assert.Equal(RentalStatus.CANCELED, rental.Status);
            Assert.NotEqual(previousStatus, rental.Status);
        }

        [Fact]
        public async Task Rental_SetAsCanceled_Should_ThrowDomainLayerException_WhenRentaIsAlreadyCanceled()
        {
            var year = DateTime.Now.AddYears(1).Year;
            var fromDate = new DateTime(year, 1, 1);
            var toDate = new DateTime(year, 1, 10);

            var rental = RentalObjectFactory.Create(fromDate, toDate);
            rental.SetAsCanceled();
            var previousStatus = rental.Status;

            Action act = () => rental.SetAsCanceled();

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("RENTAL_ALREADY_CANCELLED", exception.Title);
            Assert.Equal(previousStatus, rental.Status);
        }

        [Fact]
        public async Task Rental_SetAsFinished_Should_BeSuccess_WhenRentalTimeHasStarted()
        {
            var fromDate = DateTime.Today.AddDays(-2);
            var toDate = DateTime.Today;

            var rental = RentalObjectFactory.Create(fromDate, toDate);
            var previousStatus = rental.Status;

            rental.SetAsFinished();

            Assert.Equal(RentalStatus.FINISHED, rental.Status);
            Assert.NotEqual(previousStatus, rental.Status);
        }

        [Fact]
        public async Task Rental_SetAsFinished_Should_ThrowDomainLayerException_WhenRentalTimeHasNotStarted()
        {
            var year = DateTime.Now.AddYears(1).Year;
            var fromDate = new DateTime(year, 1, 1);
            var toDate = new DateTime(year, 1, 10);

            var rental = RentalObjectFactory.Create(fromDate, toDate);
            var previousStatus = rental.Status;

            Action act = () => rental.SetAsFinished();

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_FINISH_DATE", exception.Title);
            Assert.Equal(previousStatus, rental.Status);
        }

        [Fact]
        public async Task Rental_SetAsFinished_Should_ThrowDomainLayerException_WhenRentaIsAlreadyFinished()
        {
            var fromDate = DateTime.Today.AddDays(-2);
            var toDate = DateTime.Today;

            var rental = RentalObjectFactory.Create(fromDate, toDate);
            rental.SetAsFinished();
            var previousStatus = rental.Status;

            Action act = () => rental.SetAsFinished();

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("RENTAL_ALREADY_FINISHED", exception.Title);
            Assert.Equal(previousStatus, rental.Status);
        }
    }
}
