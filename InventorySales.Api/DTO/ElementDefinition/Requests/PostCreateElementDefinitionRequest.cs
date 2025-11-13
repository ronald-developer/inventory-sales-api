using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.ElementDefinition.Requests
{
    public class PostCreateElementDefinitionRequest
    {

        /// <summary>
        /// Name of the custom field (e.g., Chasis, EngineSize).
        /// </summary>
        [Required]
        public string ElementName { get; set; }

        /// <summary>
        /// Description or help text for this field.
        /// </summary>
        [Required]
        public string ElementDescription { get; set; }

        /// <summary>
        /// Maximum character length allowed for this field.
        /// </summary>
        [Required]
        public int Length { get; set; }

        /// <summary>
        /// Indicates whether this field is required.
        /// </summary>
        [Required]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Target entity this metadata applies to. Typically "Asset". (e.g., nameof(Asset))
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// Foreign key to metadata schema version.
        /// </summary>
        [Required]
        public int MetadataSchemaVersionId { get; set; }

        /// <summary>
        /// Foreign key to the data type for this field's value.
        /// </summary>
        [Required]
        public int DataTypeId { get; set; }

        /// <summary>
        /// Indicates if this element definition is approved and active.
        /// </summary>
        public bool IsApproved { get; set; }
    }

}
