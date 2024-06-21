using RentalCar.Domain.Cars;

namespace RentalCar.Application.UnitTests.Objects
{
    internal class CarObjectFactory
    {
        public static Car Create(float dailyPrice, int countryMinimumAge = 18)
        {
            return new Car(CarBrandObjectFactory.Create(), "key123", dailyPrice, CountryObjectFactory.Create(countryMinimumAge))
            {
                Id = 1
            };

        }
    }
}
