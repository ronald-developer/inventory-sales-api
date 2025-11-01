namespace InventorySales.EntityFramework.Core
{
    public class AssetType: AuditableEntity
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int AssetTypeId { get; set; }

        /// <summary>
        /// Display name or label for the asset.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the collection of assets associated with this instance.
        /// </summary>
        public ICollection<Asset> Assets { get; set; }
    }
}
