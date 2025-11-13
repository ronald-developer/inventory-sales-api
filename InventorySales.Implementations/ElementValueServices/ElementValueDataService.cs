using InventorySales.Contracts;
using InventorySales.Contracts.ElementValueServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Implementations.ElementValueServices
{
    public class ElementValueDataService : IElementValueDataService
    {
        private readonly IElementValueRepository repository;
        private readonly IOperationContext operationContext;

        public ElementValueDataService(IElementValueRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }

        public async Task<ElementValue> GetByIdAsync(int id)
        {
            ElementValue result = await repository.GetByIdAsync(nameof(ElementValue.ElementValueId), id);

            return result;
        }

        public async Task<IEnumerable<ElementValue>> GetAllElementValuesByElementDefinitionIdAsync(int elementDefinitionId)
        {
            IEnumerable<ElementValue> result = await repository.GetAllElementValuesByElementDefinitionIdAsync(elementDefinitionId);

            return result;
        }

    }
}
