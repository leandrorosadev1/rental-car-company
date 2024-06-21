using System.Security.Principal;

namespace RentalCar.Api.Common.Identity
{
    public class RentalCarPrincipal : IPrincipal
    {
        public IIdentity Identity { internal set; get; }

        public RentalCarPrincipal(int? userId)
        {
            IIdentity identity = new RentalCarIdentity(userId);
            Identity = identity;
        }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
