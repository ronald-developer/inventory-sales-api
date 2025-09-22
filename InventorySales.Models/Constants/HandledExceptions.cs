using InventorySales.Models.ExceptionTypes;
using System.Net;
using System.Reflection;

namespace InventorySales.Models.Constants
{
    public static class HandledExceptions
    {
        public static readonly Type[] SupportedTypes = new Type[]
        {
            typeof(NotFoundException),
            typeof(UnauthorizedException),
            typeof(BadRequestException),
            typeof(InternalServerException)
        };

        static HandledExceptions()
        {
            foreach (var type in SupportedTypes)
            {
                if (!typeof(ApplicationException).IsAssignableFrom(type))
                    throw new InvalidOperationException($"{type.Name} must inherit from ApplicationException.");
            }
        }

        public static Dictionary<Type, (HttpStatusCode StatusCode, string StatusName, string ErrorType)> ExceptionsByType => HandledExceptions.SupportedTypes.ToDictionary(
               exceptionType => exceptionType,
               exceptionType =>
               {
                   var statusCodeField = exceptionType.GetField("StatusCode", BindingFlags.Public | BindingFlags.Static);
                   var statusNameField = exceptionType.GetField("StatusName", BindingFlags.Public | BindingFlags.Static);
                   
                   if (statusCodeField == null)
                       throw new InvalidOperationException($"{exceptionType.Name} does not have a public static field named StatusCode.");

                   if (statusNameField == null)
                       throw new InvalidOperationException($"{exceptionType.Name} does not have a public static field named StatusName.");

                   var statusCode = (HttpStatusCode)statusCodeField.GetValue(null)!;
                   var statusName = (string)statusNameField.GetValue(null)!;

                   return (statusCode, "", exceptionType.Name);
               }
           );

        public static Dictionary<HttpStatusCode, (HttpStatusCode StatusCode, string StatusName, string ErrorType)> ExceptionsByCode => HandledExceptions.SupportedTypes.ToDictionary(
            exceptionType =>
            {
                var statusCodeField = exceptionType.GetField("StatusCode", BindingFlags.Public | BindingFlags.Static);
                if (statusCodeField == null)
                    throw new InvalidOperationException($"{exceptionType.Name} does not have a public static field named StatusCode.");

                var statusCode = (HttpStatusCode)statusCodeField.GetValue(null)!;
                return statusCode; 
            },
            exceptionType =>
            {
                var statusCodeField = exceptionType.GetField("StatusCode", BindingFlags.Public | BindingFlags.Static);
                var statusNameField = exceptionType.GetField("StatusName", BindingFlags.Public | BindingFlags.Static);
                
                if (statusCodeField == null)
                    throw new InvalidOperationException($"{exceptionType.Name} does not have a public static field named StatusCode.");
                
                if (statusNameField == null)
                    throw new InvalidOperationException($"{exceptionType.Name} does not have a public static field named StatusName.");

                var statusCode = (HttpStatusCode)statusCodeField.GetValue(null)!;
                var statusName = (string)statusNameField.GetValue(null)!;

                return (statusCode, statusName, exceptionType.Name);
            }
        );

    }
}
