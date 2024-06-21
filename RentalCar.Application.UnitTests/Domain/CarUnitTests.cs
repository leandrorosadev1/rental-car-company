using RentalCar.Application.UnitTests.Objects;
using RentalCar.Domain.Common;

namespace RentalCar.Application.UnitTests.Domain
{
    public class CarUnitTests
    {
        [Fact]
        public async Task Car_ValidateDailyPrice_Should_BeCalledOnConstructor_Success_WhenDailyPriceIsGreaterThanZero()
        {
            Action act = () => CarObjectFactory.Create(100);

            var exception = Record.Exception(act);

            Assert.Null(exception);
        }

        [Fact]
        public async Task Car_ValidateDailyPrice_Should_BeCalledOnConstructor_ThrowDomainLayerException_WhenDailyPriceIsZero()
        {
            Action act = () => CarObjectFactory.Create(0);

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_CAR_DAILY_PRICE", exception.Title);
        }

        [Fact]
        public async Task Car_ValidateDailyPrice_Should_BeCalledOnConstructor_ThrowDomainLayerException_WhenDailyPriceIsLowerThanZero()
        {
            Action act = () => CarObjectFactory.Create(-100);

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_CAR_DAILY_PRICE", exception.Title);
        }

        [Fact]
        public async Task Car_SetAsInactive_Should_BeSuccess_WhenCarIsActive()
        {
            var car = CarObjectFactory.Create(100);

            Action act = () => car.SetAsInactive();

            var exception = Record.Exception(act);

            Assert.Null(exception);
        }

        [Fact]
        public async Task Car_SetAsInactive_Should_ThrowDomainLayerException_WhenCarIsInactive()
        {
            var car = CarObjectFactory.Create(100);
            car.SetAsInactive();

            Action act = () => car.SetAsInactive();

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("CAR_IS_ALREADY_INACTIVE", exception.Title);
        }
    }
}
