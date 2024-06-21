namespace RentalCar.Api.Contracts
{
    public record RentalResponse(
        int Id,
        int CarId,
        string CarNumberPlate,
        int CustomerUserId,
        DateTime FromDate,
        DateTime ToDate,
        float DailyPrice,
        float TotalPrice,
        string Status);
}
