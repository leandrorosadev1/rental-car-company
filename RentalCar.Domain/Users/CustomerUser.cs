using RentalCar.Domain.Common;

namespace RentalCar.Domain.Users
{
    public sealed class CustomerUser : BaseUser
    {
        #region Constructors
        public CustomerUser(
            string firstname,
            string lastname,
            DateTime birthDate,
            Country country,
            string email,
            string password,
            string idCardNumber,
            string driverLicenseNumber) : base(firstname, lastname, birthDate, country, email, password)
        {
            IsActive = true;
            IdCardNumber = idCardNumber;
            DriverLicenseNumber = driverLicenseNumber;
            ValidateBirthDate();
        }

        private CustomerUser() : base()
        {

        }
        #endregion

        public bool IsActive { get; private set; }
        public string IdCardNumber { get; }
        public string DriverLicenseNumber { get; private set; }
        public int CurrentAge
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        #region Methods
        public void SetAsInactive()
        {
            if (!IsActive)
            {
                throw new DomainLayerException("CUSTOMER_USER_NOT_ACTIVE");
            }
            IsActive = false;
        }

        public void ValidateBirthDate()
        {
            if (BirthDate.Date >= DateTime.UtcNow.Date)
            {
                throw new DomainLayerException("INVALID_BIRTHDATE");
            }
        }
        #endregion
    }
}
