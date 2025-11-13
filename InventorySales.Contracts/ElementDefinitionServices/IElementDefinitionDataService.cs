using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.Asset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Contracts.ElementDefinitionServices
{
    public interface IElementDefinitionDataService
    {
        Task<ElementDefinition> GetByIdAsync(int id);
        Task<IEnumerable<ElementDefinition>> GetAllAsync();
    }
}
