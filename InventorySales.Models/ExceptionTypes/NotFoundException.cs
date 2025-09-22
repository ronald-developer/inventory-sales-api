using System.Net;


namespace InventorySales.Models.ExceptionTypes
{  
    public class NotFoundException : ApplicationException
    {
        public readonly static HttpStatusCode StatusCode = HttpStatusCode.NotFound;
        public readonly static string StatusName = "Not found";
        public NotFoundException(string name, object key) : base($"{name} with key: {key} was not found")
        {
        }
        public NotFoundException(object key) : base($"{key} was not found")
        {
        }
    }
}
