using RentalCar.Application.UnitTests.Objects;
using RentalCar.Domain.Common;

namespace RentalCar.Application.UnitTests.Domain
{
    public class CustomerUserUnitTests
    {
        [Fact]
        public async Task CustomerUser_ValidateBirthDate_Should_BeCalledOnConstructor_Success_WhenBirthDateIsLowerThanToday()
        {
            Action act = () => CustomerUserObjectFactory.Create();

            var exception = Record.Exception(act);

            Assert.Null(exception);
        }

        [Fact]
        public async Task CustomerUser_ValidateBirthDate_Should_BeCalledOnConstructor_ThrowDomainLayerException_WhenBirthDateIsEqualThanToday()
        {
            Action act = () => CustomerUserObjectFactory.Create(DateTime.Today);

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_BIRTHDATE", exception.Title);
        }

        [Fact]
        public async Task CustomerUser_ValidateBirthDate_Should_BeCalledOnConstructor_ThrowDomainLayerException_WhenBirthDateIsGreaterThanToday()
        {
            Action act = () => CustomerUserObjectFactory.Create(DateTime.Today.AddDays(1));

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("INVALID_BIRTHDATE", exception.Title);
        }

        [Fact]
        public async Task CustomerUser_SetAsInactive_Should_BeSuccess_WhenUserIsNotInactive()
        {
            var customerUser = CustomerUserObjectFactory.Create();
            var previousStatus = customerUser.IsActive;

            customerUser.SetAsInactive();

            Assert.Equal(false, customerUser.IsActive);
            Assert.NotEqual(previousStatus, customerUser.IsActive);
        }

        [Fact]
        public async Task CustomerUser_SetAsInactive_Should_ThrowDomainLayerException_WhenUserIsAlreadyInactive()
        {
            var customerUser = CustomerUserObjectFactory.Create();
            customerUser.SetAsInactive();
            var previousStatus = customerUser.IsActive;

            Action act = () => customerUser.SetAsInactive();

            DomainLayerException exception = Assert.Throws<DomainLayerException>(act);
            Assert.Equal("CUSTOMER_USER_NOT_ACTIVE", exception.Title);
            Assert.Equal(previousStatus, customerUser.IsActive);
        }
    }
}
