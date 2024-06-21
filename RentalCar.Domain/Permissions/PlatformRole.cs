using RentalCar.Domain.Common;

namespace RentalCar.Domain.Permissions
{
    public sealed class PlatformRole : BaseEntity
    {
        private readonly List<PlatformPermission> _permissions = new();

        #region Constructors
        public PlatformRole(string name)
        {
            Name = name;
        }

        private PlatformRole()
        {

        }
        #endregion

        public string Name { get; }
        public IReadOnlyList<PlatformPermission> Permissions => _permissions.AsReadOnly();
    }
}
