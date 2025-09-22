using System.Net;


namespace InventorySales.Models.ExceptionTypes
{
    public class InternalServerException : ApplicationException
    {
        public readonly static HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;
        public readonly static string StatusName = "Internal server error";
        public InternalServerException(string name, object key) : base($"{name} with key: {key} was not found")
        {
        }
    }
}
