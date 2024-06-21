using RentalCar.Domain.Common;

namespace RentalCar.Domain.Cars
{
    public sealed class Car : BaseEntity
    {
        public static int DefaultAvailabilityDays => 30;

        #region Constructors
        public Car(CarBrand brand, string numberPlate, float dailyPrice, Country placedInCountry) : this()
        {
            Brand = brand;
            NumberPlate = numberPlate;
            IsActive = true;
            DailyPrice = dailyPrice;
            PlacedInCountry = placedInCountry;
            ValidateDailyPrice();
        }

        private Car()
        {
            Calendar = new List<CarCalendar>();
        }
        #endregion

        public CarBrand Brand { get; }
        public string NumberPlate { get; }
        public bool IsActive { get; private set; }
        public float DailyPrice { get; private set; }
        public Country PlacedInCountry { get; private set; }
        public IList<CarCalendar> Calendar { get; private set; }

        #region Methods
        public void ValidateDailyPrice()
        {
            if (DailyPrice <= 0)
            {
                throw new DomainLayerException(
                    "INVALID_CAR_DAILY_PRICE",
                    $"Car daily price {DailyPrice} is not valid");
            }
        }

        public void SetAsInactive()
        {
            if (!IsActive)
            {
                throw new DomainLayerException("CAR_IS_ALREADY_INACTIVE");
            }
            IsActive = false;
        }
        #endregion
    }
}
