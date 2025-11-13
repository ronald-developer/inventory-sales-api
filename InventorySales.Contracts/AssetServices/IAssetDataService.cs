using InventorySales.EntityFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Contracts.AssetServices
{
    public interface IAssetDataService
    {
        Task<Asset> GetByIdAsync(int id);
        Task<IEnumerable<Asset>> GetAllAsync();
    }
}
