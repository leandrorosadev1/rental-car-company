namespace RentalCar.Api.Contracts
{
    public record CreateRentalRequest(
        int CarId,
        DateTime FromDate,
        DateTime ToDate);
}
