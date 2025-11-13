using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Contracts.DataTypeServices
{
    public interface IDataTypeDataService
    {
        Task<DataType> GetByIdAsync(int id);
        Task<IEnumerable<DataType>> GetAllAsync();
    }
}
