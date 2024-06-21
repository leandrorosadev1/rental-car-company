using RentalCar.Domain.Common;

namespace RentalCar.Domain.Users
{
    public abstract class BaseUser : BaseEntity
    {
        #region Constructors
        protected BaseUser(string firstname, string lastname, DateTime birthDate, Country country, string email, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            BirthDate = birthDate;
            Country = country;
            Email = email;
            Password = password;
        }

        protected BaseUser()
        {

        }
        #endregion

        public string Firstname { get; protected set; }
        public string Lastname { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public Country Country { get; set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }
}
