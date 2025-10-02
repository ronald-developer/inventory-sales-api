using InventorySales.EntityFramework.Metadata;
using InventorySales.EntityFramework.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.EntityFramework.Core
{

    /// <summary>
    /// Represents a generic inventory item (e.g., Truck, Car, Motorcycle).
    /// Custom fields are defined via metadata (ElementDefinitions).
    /// </summary>
    public class Asset: AuditableEntity
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int AssetId { get; set; }

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

        /// <summary>
        /// Navigation to the metadata schema version.
        /// </summary>
        public MetadataSchemaVersion MetadataSchemaVersion { get; set; }

        /// <summary>
        /// Collection of custom element values for this asset.
        /// </summary>
        public ICollection<ElementValue> ElementValues { get; set; }

        /// <summary>
        /// Collection of sales records involving this asset.
        /// </summary>
        public ICollection<Sale> Sales { get; set; }

        /// <summary>
        /// The type of asset this field applies to (e.g., Truck, Car).
        /// </summary>
        public AssetType AssetType { get; set; }

    }
}
