using InventorySales.Contracts;
using InventorySales.Contracts.MetadataSchemaVersionServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.Constants;
using InventorySales.Models.MetadataSchemaVersion;
using System.Threading.Tasks;

namespace InventorySales.Implementations.MetadataSchemaVersionServices
{
    public class MetadataSchemaVersionEntryService : IMetadataSchemaVersionEntryService
    {
        private readonly IMetadataSchemaVersionRepository repository;
        private readonly IOperationContext operationContext;

        private const string entityKey = nameof(MetadataSchemaVersion.MetadataSchemaVersionId);

        public MetadataSchemaVersionEntryService(IMetadataSchemaVersionRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }

        public async Task<MetadataSchemaVersion> CreateAsync(MetadataSchemaVersionEntryModel model)
        {
            decimal version = await GetNextVersionNumber(model.EntityName, VersionIncrementType.Major);

            MetadataSchemaVersion entity = new MetadataSchemaVersion
            {
                EntityName = model.EntityName,
                Version = version,
                VersionDescription = model.VersionDescription,
                IsActive = model.IsActive
            };

            await repository.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(entityKey, id);
        }

        public async Task<MetadataSchemaVersion> UpdateAsync(int id, MetadataSchemaVersionEntryModel model)
        {
            await repository.GetByIdAsync(entityKey, id);

            decimal version = await GetNextVersionNumber(model.EntityName, VersionIncrementType.Minor);

            MetadataSchemaVersion entity = new MetadataSchemaVersion
            {
                MetadataSchemaVersionId = id,
                EntityName = model.EntityName,
                Version = version,
                VersionDescription = model.VersionDescription,                
                IsActive = model.IsActive
            };

            await repository.UpdateAsync(entityKey, id, entity);

            return entity;
        }

        public async Task<decimal> GetNextVersionNumber(string entityName, VersionIncrementType incrementType)
        {
            decimal version = await repository.GetNextVersionNumber(entityName, incrementType);

            return version;
        }

    }
}
