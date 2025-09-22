using Microsoft.AspNetCore.Mvc.Filters;

namespace InventorySales.Api.Filters
{

    public class GlobalRequestFilter : IActionFilter
    {
        private readonly ILogger<GlobalRequestFilter> logger;


        /// <summary></summary>
        public GlobalRequestFilter(
            ILogger<GlobalRequestFilter> logger
            )
        {
            this.logger = logger;
        }

        /// <summary></summary>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("OnActionExecuted Log information");
        }

        /// <summary></summary>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("OnActionExecuting Log information");
        }
    }
}
