using InventorySales.Models.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace InventorySales.Implementations
{
    public class InventorySalesAuthorizationHandler : AuthorizationHandler<MinimumRolesAuthorizationRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public InventorySalesAuthorizationHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumRolesAuthorizationRequirement requirement)
        {
            string token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            ClaimsPrincipal decodedToken = JwtManager.DecodeJwtToken(token);

            Claim userSystemClaim = decodedToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.System); // gets the system claim & make sure that this user is intended for this app

            if (userSystemClaim != null && (!requirement.MinimumAllowedRoles.Any() || requirement.MinimumAllowedRoles.Any(role => context.User.IsInRole(role))))
            {
                context.Succeed(requirement);
            }
            else
            {
                // Allow the pipeline to continue by failing the requirement without terminating the request
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }

}
