using InventorySales.Contracts;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework;
using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Implementations.Repositories
{
    public class DataTypeRepository : GenericRepository<DataType>, IDataTypeRepository
    {
        public DataTypeRepository(InventorySalesDbContext dbContext, IOperationContext operationContext) : base(dbContext, operationContext)
        {
        }
    }
}
