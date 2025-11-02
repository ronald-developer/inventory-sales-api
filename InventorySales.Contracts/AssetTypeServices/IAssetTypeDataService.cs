using InventorySales.EntityFramework.Core;

namespace InventorySales.Contracts.AssetTypeServices
{
    public interface IAssetTypeDataService
    {
        Task<AssetType> GetByIdAsync(int id);
        Task<IEnumerable<AssetType>> GetAllAsync();
    }
}
