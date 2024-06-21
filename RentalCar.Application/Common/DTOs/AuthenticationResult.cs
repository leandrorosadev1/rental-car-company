using RentalCar.Domain.Users;

namespace RentalCar.Application.Common.DTOs
{
    public record AuthenticationResult(
        BaseUser User,
        string Token);
}
