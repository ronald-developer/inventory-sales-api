using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Models.DataType
{
    public class DataTypeEntryModel
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public int DataTypeId { get; set; }

        /// <summary>
        /// Name of the data type (e.g., String, Integer, DateTime).
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// Type sample value (e.g., "Sample String", "123", "2023-01-01").
        /// </summary>
        public string TypeValueSample { get; set; }
    }
}
