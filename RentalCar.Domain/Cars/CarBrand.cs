using RentalCar.Domain.Common;

namespace RentalCar.Domain.Cars
{
    public sealed class CarBrand : BaseEntity
    {
        #region Constructors
        private CarBrand()
        {
        }

        public CarBrand(string name)
        {
            Name = name;
        }
        #endregion

        public string Name { get; private set; }
    }
}
