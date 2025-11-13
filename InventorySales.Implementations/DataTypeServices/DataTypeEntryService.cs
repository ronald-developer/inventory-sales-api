using InventorySales.Contracts;
using InventorySales.Contracts.DataTypeServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.DataType;

namespace InventorySales.Implementations.DataTypeServices
{
    public class DataTypeEntryService : IDataTypeEntryService
    {
        private readonly IDataTypeRepository repository;
        private readonly IOperationContext operationContext;

        private const string entityKey = nameof(DataType.DataTypeId);

        public DataTypeEntryService(IDataTypeRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }

        public async Task<DataType> CreateAsync(DataTypeEntryModel model)
        {
            DataType entity = new DataType
            {
                TypeName = model.TypeName,
                TypeValueSample = model.TypeValueSample,
            };

            await repository.AddAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            await repository.DeleteAsync(entityKey, id);
        }

        public async Task<DataType> UpdateAsync(int id, DataTypeEntryModel model)
        {
            await repository.GetByIdAsync(entityKey, id);

            DataType entity = new DataType
            {
                TypeName = model.TypeName,
                TypeValueSample = model.TypeValueSample,
            };

            await repository.UpdateAsync(entityKey, id, entity);

            return entity;
        }
    }
}
