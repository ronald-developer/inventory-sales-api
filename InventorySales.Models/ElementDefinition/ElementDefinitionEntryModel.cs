using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.ElementDefinition
{
    public class ElementDefinitionEntryModel
    {
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
        /// Foreign key to the data type for this field's value.
        /// </summary>
        public int DataTypeId { get; set; }

        /// <summary>
        /// Indicates if this element definition is approved and active.
        /// </summary>
        public bool IsApproved { get; set; }
    }
}
