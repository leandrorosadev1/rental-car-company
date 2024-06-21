using RentalCar.Domain.Rentals;

namespace RentalCar.Application.UnitTests.Objects
{
    internal class RentalObjectFactory
    {
        public static Rental Create(DateTime fromDate, DateTime toDate, int carMinimumAge = 18)
        {
            var car = CarObjectFactory.Create(100, carMinimumAge);
            return new Rental(CustomerUserObjectFactory.Create(), car, fromDate, toDate, car.DailyPrice)
            {
                Id = 1
            };
        }
    }
}
