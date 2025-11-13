using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Contracts.MetadataSchemaVersionServices
{
    public interface IMetadataSchemaVersionDataService
    {
        Task<MetadataSchemaVersion> GetByIdAsync(int id);
        Task<IEnumerable<MetadataSchemaVersion>> GetAllAsync();
    }
}
