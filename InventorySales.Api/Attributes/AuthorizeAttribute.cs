using InventorySales.Models.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InventorySales.Api.Attributes
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(string roles = null) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { new MinimumRolesAuthorizationRequirement(roles) };
        }

        private class AuthorizeFilter : IAuthorizationFilter
        {
            private readonly IAuthorizationService AuthorizationService;
            private readonly MinimumRolesAuthorizationRequirement Requirement;

            public AuthorizeFilter(IAuthorizationService authorizationService, MinimumRolesAuthorizationRequirement requirement)
            {
                AuthorizationService = authorizationService;
                Requirement = requirement;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                AuthorizationResult result = AuthorizationService.AuthorizeAsync(context.HttpContext.User, null, Requirement).Result;

                if (!result.Succeeded)
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }

}
