using System.ComponentModel.DataAnnotations;

namespace InventorySales.Models.AssetType
{
    public class AssetTypeEntryModel
    {

        /// <summary>
        /// Name of the asset.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of the asset.
        /// </summary>
        [Required]
        public string Description { get; set; }

    }
}
