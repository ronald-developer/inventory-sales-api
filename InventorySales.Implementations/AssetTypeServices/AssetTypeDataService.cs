using InventorySales.Contracts;
using InventorySales.Contracts.AssetTypeServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Core;

namespace InventorySales.Implementations.AssetTypeServices
{
    public class AssetTypeDataService : IAssetTypeDataService
    {
        private readonly IAssetTypeRepository repository;
        private readonly IOperationContext operationContext;

        public AssetTypeDataService(IAssetTypeRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }
        public async Task<IEnumerable<AssetType>> GetAllAsync()
        {
            IEnumerable<AssetType> result = await repository.GetAllAsync();

            return result;
        }

        public async Task<AssetType> GetByIdAsync(int id)
        {
            AssetType result = await repository.GetByIdAsync(nameof(AssetType.AssetTypeId), id);

            return result;
        }
    }
}
