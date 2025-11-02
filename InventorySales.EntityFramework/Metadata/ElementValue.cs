namespace InventorySales.EntityFramework.Metadata
{
    /// <summary>
    /// Stores a user-provided value for a dynamic field (element) for a specific entity record.
    /// </summary>
    public class ElementValue
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

        /// <summary>
        /// Navigation to the element definition (metadata).
        /// </summary>
        public ElementDefinition ElementDefinition { get; set; }
    }
}
