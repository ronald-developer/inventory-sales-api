using InventorySales.Contracts;
using InventorySales.Contracts.AssetServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Core;

namespace InventorySales.Implementations.AssetServices
{
    public class AssetDataService : IAssetDataService
    {
        private readonly IAssetRepository repository;
        private readonly IOperationContext operationContext;

        public AssetDataService(IAssetRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }
        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            IEnumerable<Asset> result = await repository.GetAllAsync();

            return result;
        }

        public async Task<Asset> GetByIdAsync(int id)
        {
            Asset result = await repository.GetByIdAsync(nameof(Asset.AssetId), id);

            return result;
        }
    }
}
