namespace RentalCar.Api.Contracts
{
    public record AuthenticationResponse(
        int Id,
        string Firstname,
        string Lastname,
        string Email,
        string Token);
}
