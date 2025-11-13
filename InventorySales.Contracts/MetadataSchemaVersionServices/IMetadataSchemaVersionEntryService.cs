using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.Constants;
using InventorySales.Models.MetadataSchemaVersion;

namespace InventorySales.Contracts.MetadataSchemaVersionServices
{
    public interface IMetadataSchemaVersionEntryService
    {
        Task<MetadataSchemaVersion> CreateAsync(MetadataSchemaVersionEntryModel model);
        Task<MetadataSchemaVersion> UpdateAsync(int id, MetadataSchemaVersionEntryModel model);
        Task DeleteAsync(int id);
        Task<decimal> GetNextVersionNumber(string entityName, VersionIncrementType incrementType);
    }
}
