using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.MetadataSchemaVersion.Requests
{
    public class PutUpdateMetadataSchemaVersionRequest
    {
        /// <summary>
        /// Name of the entity this schema version applies to (e.g., "Asset", "Customer").
        /// </summary
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// Description or notes about this version. (e.g. "draft")
        /// </summary>
        [Required]
        public string VersionDescription { get; set; }

        /// <summary>
        /// Indicates whether this version is currently active.
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
    }
}
