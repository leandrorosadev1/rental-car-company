using RentalCar.Domain.Common;

namespace RentalCar.Application.UnitTests.Objects
{
    internal class CountryObjectFactory
    {
        public static Country Create(int countryMinimumAge = 18)
        {
            return new Country("Argentina", countryMinimumAge) { Id = 1 };
        }
    }
}
