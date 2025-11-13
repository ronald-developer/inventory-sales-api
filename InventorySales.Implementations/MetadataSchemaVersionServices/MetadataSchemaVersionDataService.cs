using InventorySales.Contracts;
using InventorySales.Contracts.MetadataSchemaVersionServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Implementations.MetadataSchemaVersionServices
{
    public class MetadataSchemaVersionDataService : IMetadataSchemaVersionDataService
    {
        private readonly IMetadataSchemaVersionRepository repository;
        private readonly IOperationContext operationContext;

        public MetadataSchemaVersionDataService(IMetadataSchemaVersionRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }
        public async Task<IEnumerable<MetadataSchemaVersion>> GetAllAsync()
        {
            IEnumerable<MetadataSchemaVersion> result = await repository.GetAllAsync();

            return result;
        }

        public async Task<MetadataSchemaVersion> GetByIdAsync(int id)
        {
            MetadataSchemaVersion result = await repository.GetByIdAsync(nameof(MetadataSchemaVersion.MetadataSchemaVersionId), id, new string[] { "ElementDefinitions", "Assets" });

            return result;
        }
    }
}
