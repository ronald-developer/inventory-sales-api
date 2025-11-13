using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.ElementDefinition;

namespace InventorySales.Contracts.ElementDefinitionServices
{
    public interface IElementDefinitionEntryService {
        Task<ElementDefinition> CreateAsync(ElementDefinitionEntryModel model);
        Task<ElementDefinition> UpdateAsync(int id, ElementDefinitionEntryModel model);
        Task DeleteAsync(int id);
    }
}
