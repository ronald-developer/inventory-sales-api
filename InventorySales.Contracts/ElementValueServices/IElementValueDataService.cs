using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Contracts.ElementValueServices
{
    public interface IElementValueDataService {
        Task<ElementValue> GetByIdAsync(int id);
        Task<IEnumerable<ElementValue>> GetAllElementValuesByElementDefinitionIdAsync(int elementDefinitionId);
    }
}
