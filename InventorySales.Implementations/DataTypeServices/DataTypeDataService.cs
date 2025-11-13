using InventorySales.Contracts;
using InventorySales.Contracts.DataTypeServices;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework.Core;
using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Implementations.DataTypeServices
{
    public class DataTypeDataService : IDataTypeDataService
    {
        private readonly IDataTypeRepository repository;
        private readonly IOperationContext operationContext;

        public DataTypeDataService(IDataTypeRepository repository, IOperationContext operationContext)
        {
            this.repository = repository;
            this.operationContext = operationContext;
        }
        public async Task<IEnumerable<DataType>> GetAllAsync()
        {
            IEnumerable<DataType> result = await repository.GetAllAsync();

            return result;
        }

        public async Task<DataType> GetByIdAsync(int id)
        {
            DataType result = await repository.GetByIdAsync(nameof(DataType.DataTypeId), id);

            return result;
        }
    }
}
