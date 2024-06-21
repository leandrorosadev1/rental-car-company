using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common.Identity;
using System.Security.Claims;

namespace RentalCar.Api.Common
{
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        protected IMapper Mapper { get; }

        public BaseController(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccesor = httpContextAccessor;
            Mapper = mapper;

            SetUpCurrentUserOnThread();
        }

        protected int? GetCurrentUserId()
        {
            return GetCurrentUserIdFromClaims();
        }

        protected bool CurrentUserIsAdmin
        {
            get
            {
                var claim = _httpContextAccesor.HttpContext.User.Claims.Where(x => x.Type == "platformrole").SingleOrDefault();

                return claim != null && claim.Value.ToUpper() == "ADMIN";
            }
        }

        private void SetUpCurrentUserOnThread()
        {
            int? userId = null;

            var userIdClaim = GetUserIdClaim();
            if (userIdClaim != null)
            {
                userId = int.Parse(userIdClaim.Value);
            }
            Thread.CurrentPrincipal = new RentalCarPrincipal(userId);
        }

        private int? GetCurrentUserIdFromClaims()
        {
            var claim = GetUserIdClaim();

            if (claim == null)
            {
                return null;
            }

            return int.Parse(claim.Value);
        }

        private Claim GetUserIdClaim()
        {
            return _httpContextAccesor.HttpContext.User.Claims.Where(x => x.Type == "userid").SingleOrDefault();
        }

        protected T MapTo<T>(object item)
        {
            return Mapper.Map<T>(item);
        }
    }
}