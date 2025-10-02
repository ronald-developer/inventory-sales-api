namespace InventorySales.EntityFramework.Core
{
    public class Inventory : AuditableEntity {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int InventoryId { get; set; }
        /// <summary>
        /// Foreign key to the asset in inventory.
        /// </summary>
        public int AssetId { get; set; }
        /// <summary>
        /// Asset quantity available in inventory.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Navigation property to the associated asset.
        /// </summary>
        public Asset Asset { get; set; }
    }
}
