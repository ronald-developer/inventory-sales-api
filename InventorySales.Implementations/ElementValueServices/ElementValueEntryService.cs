using InventorySales.Contracts;
using InventorySales.Contracts.ElementValueServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.ElementValue;

namespace InventorySales.Implementations.ElementValueServices
{
    public class ElementValueEntryService : IElementValueEntryService
    {
        private readonly IElementValueRepository repository;
        private readonly IOperationContext operationContext;

        private const string entityKey = nameof(ElementValue.ElementValueId);

        public ElementValueEntryService(IElementValueRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }

        public async Task<ElementValue> CreateAsync(ElementValueEntryModel model)
        {
            ElementValue entity = new ElementValue
            {
                ElementDefinitionId = model.ElementDefinitionId,
                EntityName = model.EntityName,
                EntityRecordId = model.EntityRecordId,
                Value = model.Value,
            };

            await repository.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(entityKey, id);
        }

        public async Task<ElementValue> UpdateAsync(int id, ElementValueEntryModel model)
        {
            await repository.GetByIdAsync(entityKey, id);

            ElementValue entity = new ElementValue
            {
                ElementDefinitionId = model.ElementDefinitionId,
                EntityName = model.EntityName,
                EntityRecordId = model.EntityRecordId,
                Value = model.Value
            };

            await repository.UpdateAsync(entityKey, id, entity);

            return entity;
        }
    }
}
