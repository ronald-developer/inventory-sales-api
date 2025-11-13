using InventorySales.Contracts;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework;
using InventorySales.EntityFramework.Core;

namespace InventorySales.Implementations.Repositories
{
    public class AssetTypeRepository : GenericRepository<AssetType>, IAssetTypeRepository
    {
        public AssetTypeRepository(InventorySalesDbContext dbContext, IOperationContext operationContext) : base(dbContext, operationContext)
        {
        }
    }
}
