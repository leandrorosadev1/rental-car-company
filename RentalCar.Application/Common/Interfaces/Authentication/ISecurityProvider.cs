namespace RentalCar.Application.Common.Interfaces.Authentication
{
    public interface ISecurityProvider
    {
        string GenerateToken(int userId, string firstname, string lastname, string role, IList<string> permissions);
        string HashPassword(string password);
    }
}
