using InventorySales.Api.Attributes;
using InventorySales.Models.Constants;
using InventorySales.Models.ExceptionTypes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;
using System.Text.Json;

namespace InventorySales.Api.Filters
{
    public class CustomApiConventionOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var customAttr = context.MethodInfo
                .GetCustomAttributes(typeof(ApiResponseDocumentationAttribute), false)
                .FirstOrDefault() as ApiResponseDocumentationAttribute;

            if (customAttr == null) return;

            foreach (var statusCode in customAttr.StatusCodes)
            {
                var statusStr = statusCode.ToString();

                if (!operation.Responses.ContainsKey(statusStr))
                {
                    var statusName = GetStatusName(statusCode);
                    var response = new OpenApiResponse
                    {
                        Description = !string.IsNullOrEmpty(statusName) ? statusName: "This status code is not supported",
                        Content = new Dictionary<string, OpenApiMediaType>()
                    };

                    if (!string.IsNullOrEmpty(statusName))
                    {
                        var errorExample = new ErrorDetails
                        {
                            ErrorMessage = "The error message.",
                            ErrorType = "Error type",
                            Errors = new Dictionary<string, string[]>
                        {
                            { "SampleErrorProperty1", new[] { "Description of this error 1" } },
                            { "SampleErrorProperty2", new[] { "Description of this error 2" } }
                        }
                        };

                        response.Content["application/json"] = new OpenApiMediaType
                        {
                            Example = OpenApiAnyFactory.CreateFromJson(JsonSerializer.Serialize(errorExample)),
                            Schema = context.SchemaGenerator.GenerateSchema(typeof(ErrorDetails), context.SchemaRepository)
                        };

                    }

                    operation.Responses[statusStr] = response;
                }
            }           
        }

        private static string GetStatusName(HttpStatusCode code) => HandledExceptions.ExceptionsByCode.TryGetValue(code, out var value)
        ? value.StatusName
        : null;

    }

}
