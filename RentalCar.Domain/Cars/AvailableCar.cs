namespace RentalCar.Domain.Cars
{
    public record AvailableCar(
        int Id,
        string BrandName,
        string NumberPlate,
        float DailyPrice,
        int TotalCount);
}
