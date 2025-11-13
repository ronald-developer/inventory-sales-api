namespace InventorySales.Api.DTO.ElementValue.Models
{
    public class DTOElementValueModel
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int ElementValueId { get; set; }

        /// <summary>
        /// Foreign key to the associated element definition (field metadata).
        /// </summary>
        public int ElementDefinitionId { get; set; }

        /// <summary>
        /// Name of the entity this value belongs to. Typically "Asset".
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// ID of the entity record this value is assigned to (e.g., AssetId).
        /// </summary>
        public int EntityRecordId { get; set; }

        /// <summary>
        /// The actual value provided for this field.
        /// </summary>
        public string Value { get; set; }
    }
}
