using InventorySales.Contracts;
using InventorySales.Models.Constants;
using InventorySales.Models.ExceptionTypes;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace InventorySales.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<ExceptionMiddleware> logger;

        //private readonly Dictionary<Type, (HttpStatusCode StatusCode, string ErrorType)> exceptions = new Dictionary<Type, (HttpStatusCode StatusCode, string ErrorType)>{
        //        { typeof(NotFoundException), (NotFoundException.StatusCode, nameof(NotFoundException)) },
        //        { typeof(UnauthorizedException), (UnauthorizedException.StatusCode, nameof(UnauthorizedException)) },
        //        { typeof(BadRequestException), (BadRequestException.StatusCode, nameof(BadRequestException)) }
        //};

        private readonly Dictionary<Type, (HttpStatusCode StatusCode, string StatusName, string ErrorType)> exceptions = HandledExceptions.ExceptionsByType;



        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Log request method and path
                logger.LogInformation($"Request: {context.Request.Method}, {context.Request.Path}");
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong while processing {context.Request.Method}, {context.Request.Path}");
                await HandleExceptionAsync(context, ex);
            }
        }


        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            ErrorDetails errorDetails = new ErrorDetails
            {
                ErrorMessage = ex.Message,
                ErrorType = "Unexpected error occurred"
            };

            if (exceptions.TryGetValue(ex.GetType(), out var value))
            {
                statusCode = value.StatusCode;
                errorDetails.ErrorType = value.ErrorType;
                //errorDetails.Errors
            }

            string response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(response);
        }
    }

}
