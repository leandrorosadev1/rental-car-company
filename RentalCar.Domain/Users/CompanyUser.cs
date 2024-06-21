using RentalCar.Domain.Common;
using RentalCar.Domain.Permissions;

namespace RentalCar.Domain.Users
{
    public sealed class CompanyUser : BaseUser
    {
        #region Constructors
        public CompanyUser(
            string firstname,
            string lastname,
            DateTime birthDate,
            Country country,
            string email,
            string password,
            PlatformRole platformRole) : base(firstname, lastname, birthDate, country, email, password)
        {
            PlatformRole = platformRole;
        }

        private CompanyUser() : base()
        {

        }
        #endregion

        public PlatformRole PlatformRole { get; private set; }
    }
}

