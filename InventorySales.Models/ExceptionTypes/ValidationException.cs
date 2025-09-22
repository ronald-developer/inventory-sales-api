using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InventorySales.Models.ExceptionTypes
{
    public class ValidationException : ValidationProblemDetails
    {
        public ValidationException(ActionContext context)
        {
            Title = "One or more validation errors occurred.";

            Status = StatusCodes.Status400BadRequest;

            Dictionary<string, string[]> errors = context.ModelState
             .Where(e => e.Value.Errors.Count > 0)
             .ToDictionary(
                 kvp => kvp.Key,
                 kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
             );

            foreach (var (key, value) in errors)
            {
                Errors.Add(key, value);
            }
        }
    }
}
