using System.Net;

namespace InventorySales.Models.ExceptionTypes
{
    public class UnauthorizedException : ApplicationException
    {
        public readonly static HttpStatusCode StatusCode = HttpStatusCode.Unauthorized;
        public readonly static string StatusName = "Unauthorized";
        public UnauthorizedException() : base("Unauthorized")
        {

        }
    }
}
