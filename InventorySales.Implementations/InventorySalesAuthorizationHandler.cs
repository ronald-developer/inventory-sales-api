using InventorySales.Contracts;
using InventorySales.Models.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace InventorySales.Implementations
{
    public class InventorySalesAuthorizationHandler : AuthorizationHandler<MinimumRolesAuthorizationRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IJwtManager jwtManager;
        private readonly TokenValidationParameters validationParameters;

        public InventorySalesAuthorizationHandler(IHttpContextAccessor httpContextAccessor, IJwtManager jwtManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.jwtManager = jwtManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumRolesAuthorizationRequirement requirement)
        {
            Claim userSystemClaim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.System); // gets the system claim & make sure that this user is intended for this app

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
