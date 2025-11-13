using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.Asset
{
    public class AssetEntryModel
    {
        /// <summary>
        /// Foreign key to the type of asset this field applies to.
        /// </summary>
        public int AssetTypeId { get; set; }

        /// <summary>
        /// Base or default price of the asset.
        /// </summary>
        public decimal? BasePrice { get; set; }

        /// <summary>
        /// Foreign key to metadata schema version.
        /// The metadata schema version used for this asset's dynamic fields.
        /// From latest version in MetadataSchemaVersion.Version where EntityName = "nameof Asset".
        /// </summary>
        public int MetadataSchemaVersionId { get; set; }

    }
}
