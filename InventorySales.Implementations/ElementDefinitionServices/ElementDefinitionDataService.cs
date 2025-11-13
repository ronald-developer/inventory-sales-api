using InventorySales.Contracts;
using InventorySales.Contracts.ElementDefinitionServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Implementations.ElementDefinitionServices
{
    public class ElementDefinitionDataService : IElementDefinitionDataService
    {
        private readonly IElementDefinitionRepository repository;
        private readonly IOperationContext operationContext;

        public ElementDefinitionDataService(IElementDefinitionRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }
        public async Task<IEnumerable<ElementDefinition>> GetAllAsync()
        {
            IEnumerable<ElementDefinition> result = await repository.GetAllAsync();

            return result;
        }

        public async Task<ElementDefinition> GetByIdAsync(int id)
        {
            ElementDefinition result = await repository.GetByIdAsync(nameof(ElementDefinition.ElementDefinitionId), id);

            return result;
        }
    }
}
