using RentalCar.Domain.Common;
using RentalCar.Domain.Users;

namespace RentalCar.Application.UnitTests.Objects
{
    internal class CustomerUserObjectFactory
    {

        public static CustomerUser Create(DateTime? birthdate = null)
        {
            DateTime bdate = birthdate.HasValue ? birthdate.Value : new DateTime(1999, 04, 02);

            return new CustomerUser(
                "Juan",
                "Perez",
                bdate,
                new Country("Argentina", 18),
                "juan@example.com",
                "pass",
                "idFake",
                "licenseFake")
            {
                Id = 1
            };
        }
    }
}
