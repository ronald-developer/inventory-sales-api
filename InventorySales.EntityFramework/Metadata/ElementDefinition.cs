using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.EntityFramework.Metadata
{
    /// <summary>
    /// Defines a dynamic field (element) for a specific asset type and schema version.
    /// Used to store metadata configuration.
    /// </summary>
    public class ElementDefinition
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int ElementDefinitionId { get; set; }

        /// <summary>
        /// Name of the custom field (e.g., Chasis, EngineSize).
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        /// Description or help text for this field.
        /// </summary>
        public string ElementDescription { get; set; }

        /// <summary>
        /// Maximum character length allowed for this field.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Indicates whether this field is required.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Target entity this metadata applies to. Typically "Asset". (e.g., nameof(Asset))
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Foreign key to metadata schema version.
        /// </summary>
        public int MetadataSchemaVersionId { get; set; }

        /// <summary>
        /// Navigation to the metadata schema version.
        /// </summary>
        public MetadataSchemaVersion MetadataSchemaVersion { get; set; }

        /// <summary>
        /// Foreign key to the data type for this field's value.
        /// </summary>
        public int DataTypeId { get; set; }

        /// <summary>
        /// Navigation to the data type.
        /// </summary>
        public DataType DataType { get; set; }

        /// <summary>
        /// Indicates if this element definition is approved and active.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Navigation to the values assigned for this definition.
        /// </summary>
        public ICollection<ElementValue> ElementValues { get; set; }
    }
}
