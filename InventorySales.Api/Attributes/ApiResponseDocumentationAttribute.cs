using System.Net;

namespace InventorySales.Api.Attributes
{
    /// <summary>
    /// Specifies a custom set of HTTP status codes to be used as API convention response types
    /// for a given controller action method.
    /// </summary>
    /// <remarks>
    /// The <see cref="StatusCodes"/> property holds an array of HTTP status code integers (e.g., 200, 400, 500).
    /// When applied to a method, this attribute can be used to dynamically generate
    /// corresponding <c>ProducesResponseType</c> attributes for Swagger/OpenAPI documentation,
    /// representing the possible responses of that endpoint.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ApiResponseDocumentationAttribute : Attribute
    {
        public HttpStatusCode[] StatusCodes { get; }

        public ApiResponseDocumentationAttribute(params HttpStatusCode[] statusCodes)
        {
            StatusCodes = statusCodes;
        }
    }

}
