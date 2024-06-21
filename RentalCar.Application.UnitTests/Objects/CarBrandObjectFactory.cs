using RentalCar.Domain.Cars;

namespace RentalCar.Application.UnitTests.Objects
{
    internal class CarBrandObjectFactory
    {
        public static CarBrand Create()
        {
            return new CarBrand("Chevrolet") { Id = 1 };
        }
    }
}
