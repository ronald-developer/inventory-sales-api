using InventorySales.Contracts;
using InventorySales.Contracts.ElementDefinitionServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.ElementDefinition;

namespace InventorySales.Implementations.ElementDefinitionServices
{
    public class ElementDefinitionEntryService : IElementDefinitionEntryService
    {
        private readonly IElementDefinitionRepository repository;
        private readonly IOperationContext operationContext;

        private const string entityKey = nameof(ElementDefinition.ElementDefinitionId);

        public ElementDefinitionEntryService(IElementDefinitionRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }

        public async Task<ElementDefinition> CreateAsync(ElementDefinitionEntryModel model)
        {
            ElementDefinition entity = new ElementDefinition
            {
                ElementName = model.ElementName,
                ElementDescription = model.ElementDescription,
                Length = model.Length,
                IsRequired = model.IsRequired,
                EntityName = model.EntityName,
                MetadataSchemaVersionId = model.MetadataSchemaVersionId,
                DataTypeId = model.DataTypeId,
                IsApproved = model.IsApproved

            };

            await repository.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(entityKey, id);
        }

        public async Task<ElementDefinition> UpdateAsync(int id, ElementDefinitionEntryModel model)
        {
            await repository.GetByIdAsync(entityKey, id);

            ElementDefinition entity = new ElementDefinition
            {
                ElementName = model.ElementName,
                ElementDescription = model.ElementDescription,
                Length = model.Length,
                IsRequired = model.IsRequired,
                EntityName = model.EntityName,
                MetadataSchemaVersionId = model.MetadataSchemaVersionId,
                DataTypeId = model.DataTypeId,
                IsApproved = model.IsApproved
            };

            await repository.UpdateAsync(entityKey, id, entity);

            return entity;
        }
    }
}
