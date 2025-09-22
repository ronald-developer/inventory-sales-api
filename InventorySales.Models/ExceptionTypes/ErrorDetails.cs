namespace InventorySales.Models.ExceptionTypes
{
    public class ErrorDetails
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
