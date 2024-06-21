namespace RentalCar.Domain.Common
{
    public class DomainLayerException : Exception
    {
        public DomainLayerException(string title, string detail = "")
        {
            Title = title;
            Detail = detail;
        }
        public string Title { get; }
        public string Detail { get; }
    }
}
