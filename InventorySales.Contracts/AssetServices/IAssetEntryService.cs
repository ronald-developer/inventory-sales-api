using InventorySales.EntityFramework.Core;
using InventorySales.Models.Asset;

namespace InventorySales.Contracts.AssetServices
{
    public interface IAssetEntryService
    {
        Task<Asset> CreateAsync(AssetEntryModel model);
        Task<Asset> UpdateAsync(int id, AssetEntryModel model);
        Task DeleteAsync(int id);
    }
}
