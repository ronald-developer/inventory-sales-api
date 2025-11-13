using System.Net;


namespace InventorySales.Models.ExceptionTypes
{
    public class InternalServerException : ApplicationException
    {
        public readonly static HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
        public readonly static string StatusName = "Internal server error";
        public InternalServerException(string name, string message) : base($"{name} error: {message}")
        {
        }
    }
}
