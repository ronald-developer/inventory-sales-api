using System.Net;

namespace InventorySales.Models.ExceptionTypes
{

    public class BadRequestException : ApplicationException
    {
        public readonly static HttpStatusCode StatusCode = HttpStatusCode.BadRequest;
        public readonly static string StatusName = "Bad request";
        public readonly IDictionary<string, string> Errors;
        public BadRequestException(string name, object key) : base($"An error occurred in: {name} {key}")
        {
        }

        public BadRequestException(string message) : base($"{message}")
        {
        }
        public BadRequestException(string message, IDictionary<string, string[]> errors) : base($"{message}")
        {
        }
    }
}
