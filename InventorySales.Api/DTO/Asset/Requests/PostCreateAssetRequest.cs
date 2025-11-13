using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.Asset.Requests
{
    public class PostCreateAssetRequest
    {
        /// <summary>
        /// Foreign key to the type of asset this field applies to.
        /// </summary>
        [Required]
        public int AssetTypeId { get; set; }

        /// <summary>
        /// Base or default price of the asset.
        /// </summary>
        [Required]
        public decimal? BasePrice { get; set; }

        /// <summary>
        /// Foreign key to metadata schema version.
        /// The metadata schema version used for this asset's dynamic fields.
        /// From latest version in MetadataSchemaVersion.Version where EntityName = "nameof Asset".
        /// </summary>
        [Required]
        public int MetadataSchemaVersionId { get; set; }
    }
}
