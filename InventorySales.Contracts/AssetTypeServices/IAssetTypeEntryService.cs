using InventorySales.EntityFramework;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.AssetType;

namespace InventorySales.Contracts.AssetTypeServices
{
    public interface IAssetTypeEntryService
    {
        Task<AssetType> CreateAsync(AssetTypeEntryModel model);
        Task<AssetType> UpdateAsync(int id, AssetTypeEntryModel model);
        Task DeleteAsync(int id);
    }

}
