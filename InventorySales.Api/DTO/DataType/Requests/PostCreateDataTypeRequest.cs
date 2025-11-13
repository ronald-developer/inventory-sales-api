using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.DataType.Requests
{
    public class PostCreateDataTypeRequest
    {
        /// <summary>
        /// Name of the data type (e.g., String, Integer, DateTime).
        /// </summary>
        [Required]
        public string TypeName { get; set; }

        /// <summary>
        /// Type sample value (e.g., "Sample String", "123", "2023-01-01").
        /// </summary>
        [Required]
        public string TypeValueSample { get; set; }
    }
}
