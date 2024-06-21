namespace RentalCar.Application.Common.Exceptions
{
    public class ApplicationLayerException : Exception
    {
        public ApplicationLayerException(ApplicationLayerExceptionType type, string title, string detail = "")
        {
            Type = type;
            Title = title;
            Detail = detail;
        }
        public ApplicationLayerExceptionType Type { get; }
        public string Title { get; }
        public string Detail { get; }
    }
}
