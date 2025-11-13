using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.ElementValue.Requests
{
    public class PostCreateElementValueRequest
    {

        /// <summary>
        /// Foreign key to the associated element definition (field metadata).
        /// </summary>
        [Required]
        public int ElementDefinitionId { get; set; }

        /// <summary>
        /// Name of the entity this value belongs to. Typically "Asset".
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// ID of the entity record this value is assigned to (e.g., AssetId).
        /// </summary>
        [Required]
        public int EntityRecordId { get; set; }

        /// <summary>
        /// The actual value provided for this field.
        /// </summary>
        [Required]
        public string Value { get; set; }
    }

}
