using InventorySales.Models.ExceptionTypes;
using Microsoft.AspNetCore.Authorization;

namespace InventorySales.Api.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<AuthorizationMiddleware> logger;

        public AuthorizationMiddleware(RequestDelegate next, ILogger<AuthorizationMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Endpoint endpoint = context.GetEndpoint();

            bool isApiURL = context.Request.Path.StartsWithSegments("/api");
            if (endpoint != null && isApiURL)
            {
                IAllowAnonymous allowAnonymous = endpoint.Metadata.GetMetadata<IAllowAnonymous>();
                if (allowAnonymous == null && !context.User.Identity.IsAuthenticated)
                {
                    throw new UnauthorizedException();
                }
            }

            await next(context);
        }
    }

}
