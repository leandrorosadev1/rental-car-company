using System.ComponentModel.DataAnnotations;

namespace RentalCar.Api.Contracts
{
    public class LoginRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
