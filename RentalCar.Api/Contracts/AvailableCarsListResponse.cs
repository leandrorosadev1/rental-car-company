namespace RentalCar.Api.Contracts
{
    public class AvailableCarsListResponse
    {
        public AvailableCarsListResponse()
        {
            Data = new List<AvailableCarResponse>();
        }
        public List<AvailableCarResponse> Data { get; set; }
        public int TotalResults { get; set; }

        public class AvailableCarResponse
        {
            public AvailableCarResponse(int id, string brandName, string numberPlate, float dailyPrice)
            {
                Id = id;
                BrandName = brandName;
                NumberPlate = numberPlate;
                DailyPrice = dailyPrice;
            }
            public int Id { get; set; }
            public string BrandName { get; set; }
            public string NumberPlate { get; set; }
            public float DailyPrice { get; set; }
        }
    }
}
