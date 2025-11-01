using InventorySales.Contracts;
using InventorySales.Contracts.AssetTypeServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.AssetType;

namespace InventorySales.Implementations.AssetTypeServices
{

    public class AssetTypeEntryService : IAssetTypeEntryService
    {
        private readonly IAssetTypeRepository repository;
        private readonly IOperationContext operationContext;

        private const string entityKey = nameof(AssetType.AssetTypeId);

        public AssetTypeEntryService(IAssetTypeRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }

        public async Task<AssetType> CreateAsync(AssetTypeEntryModel entry)
        {
            AssetType entity = new AssetType
            {
                Name = entry.Name,
                Description = entry.Description,
                CreatedByUserId = operationContext.UserId.ToString()
            };

            await repository.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(entityKey, id);
        }

        public async Task<AssetType> UpdateAsync(int id, AssetTypeEntryModel model)
        {
            await repository.GetByIdAsync(entityKey, id);

            AssetType entity = new AssetType
            {
                Name = model.Name,
                Description = model.Description,
                UpdatedByUserId = operationContext.UserId.ToString(),
                UpdatedAt = DateTime.UtcNow
            };

            await repository.UpdateAsync(entityKey, id, entity);

            return entity;
        }
    }
}
