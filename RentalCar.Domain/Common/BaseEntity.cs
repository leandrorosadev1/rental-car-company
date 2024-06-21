namespace RentalCar.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUser { get; set; }
        public int? ModifiedUser { get; set; }
    }
}
