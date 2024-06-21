using RentalCar.Domain.Common;

namespace RentalCar.Domain.Permissions
{
    public sealed class PlatformPermission : BaseEntity
    {
        #region Constructors
        public PlatformPermission(string name, string description)
        {
            Name = name;
            Description = description;
        }

        private PlatformPermission()
        {

        }
        #endregion

        public string Name { get; }
        public string Description { get; }
    }
}
