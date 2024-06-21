using System.Security.Principal;

namespace RentalCar.Api.Common.Identity
{
    public class RentalCarIdentity : IIdentity
    {
        public string AuthenticationType { internal set; get; }

        public bool IsAuthenticated { internal set; get; }

        public string Name { internal set; get; }

        public RentalCarIdentity(int? userId)
        {
            Name = userId.HasValue ? userId.Value.ToString() : null;
            IsAuthenticated = userId.HasValue;
            AuthenticationType = string.Empty;
        }
    }
}
