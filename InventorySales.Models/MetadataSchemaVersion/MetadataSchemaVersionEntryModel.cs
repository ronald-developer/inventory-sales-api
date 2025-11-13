using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.MetadataSchemaVersion
{
    public class MetadataSchemaVersionEntryModel
    {        

        /// <summary>
        /// Name of the entity this schema version applies to (e.g., "Asset", "Customer").
        /// </summary>
        public string EntityName { get; set; }       

        /// <summary>
        /// Description or notes about this version. (e.g. "draft")
        /// </summary>
        public string VersionDescription { get; set; }

        /// <summary>
        /// Indicates whether this version is currently active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
