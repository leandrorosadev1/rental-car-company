namespace RentalCar.Domain.Common
{
    public sealed class Country : BaseEntity
    {
        #region Constructors
        public Country(string name, int driverMinimumAge)
        {
            Name = name;
            DriverMinimumAge = driverMinimumAge;
        }

        private Country()
        {

        }
        #endregion

        public string Name { get; private set; }
        public int DriverMinimumAge { get; private set; }
    }
}
