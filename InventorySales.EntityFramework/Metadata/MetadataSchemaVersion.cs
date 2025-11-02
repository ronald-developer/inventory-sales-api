using InventorySales.EntityFramework.Core;

namespace InventorySales.EntityFramework.Metadata
{
    public class MetadataSchemaVersion
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int MetadataSchemaVersionId { get; set; }

        /// <summary>
        /// Name of the entity this schema version applies to (e.g., "Asset", "Customer").
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Version number of the metadata schema. (e.g., 1, 2, 3)
        /// </summary>
        public decimal Version { get; set; }

        /// <summary>
        /// Description or notes about this version. (e.g. "draft")
        /// </summary>
        public string VersionDescription { get; set; }

        /// <summary>
        /// Indicates whether this version is currently active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Element definitions associated with this schema version.
        /// </summary>
        public ICollection<ElementDefinition> ElementDefinitions { get; set; }

        /// <summary>
        /// Assets associated with this metadata schema version.
        /// </summary>
        public ICollection<Asset> Assets { get; set; }
    }
}
