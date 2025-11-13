using InventorySales.Contracts;
using InventorySales.Contracts.AssetServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.Asset;

namespace InventorySales.Implementations.AssetServices
{
    public class AssetEntryService : IAssetEntryService
    {
        private readonly IAssetRepository repository;
        private readonly IOperationContext operationContext;

        private const string entityKey = nameof(Asset.AssetId);

        public AssetEntryService(IAssetRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }

        public async Task<Asset> CreateAsync(AssetEntryModel model)
        {
            Asset entity = new Asset
            {
                AssetTypeId = model.AssetTypeId,
                MetadataSchemaVersionId = model.MetadataSchemaVersionId,
                BasePrice = model.BasePrice,
                CreatedByUserId = operationContext.UserId.ToString()
            };

            await repository.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(entityKey, id);
        }

        public async Task<Asset> UpdateAsync(int id, AssetEntryModel model)
        {
            await repository.GetByIdAsync(entityKey, id);

            Asset entity = new Asset
            {
                AssetTypeId = model.AssetTypeId,
                MetadataSchemaVersionId = model.MetadataSchemaVersionId,
                BasePrice = model.BasePrice,
                UpdatedByUserId = operationContext.UserId.ToString(),
                UpdatedAt = DateTime.UtcNow
            };

            await repository.UpdateAsync(entityKey, id, entity);

            return entity;
        }
    }
}
