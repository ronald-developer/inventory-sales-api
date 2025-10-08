namespace InventorySales.EntityFramework.Core
{
    /// <summary>
    /// Represents an entity that tracks audit information, including creation and modification details.
    /// </summary>
    public abstract class AuditableEntity
    {
        public string CreatedByUserId { get; set; }
        public string? UpdatedByUserId { get; set; }
        /// <summary>
        /// Timestamp when the asset was added to the system.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public AppUser CreatedByUser { get; set; }

        /// <summary>
        /// Timestamp when the asset was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
        public AppUser UpdatedByUser { get; set; }
    }
}
