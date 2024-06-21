using System.ComponentModel.DataAnnotations;

namespace RentalCar.Api.Contracts
{
    public class RegisterRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public int CountryId { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdCardNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
    }
}
