using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.Asset;
using InventorySales.Models.ElementValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySales.Contracts.ElementValueServices
{
    public interface IElementValueEntryService
    {
        Task<ElementValue> CreateAsync(ElementValueEntryModel model);
        Task<ElementValue> UpdateAsync(int id, ElementValueEntryModel model);
        Task DeleteAsync(int id);
    }
}
