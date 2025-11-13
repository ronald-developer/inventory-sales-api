using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.DataType;

namespace InventorySales.Contracts.DataTypeServices
{
    public interface IDataTypeEntryService
    {
        Task<DataType> CreateAsync(DataTypeEntryModel model);
        Task<DataType> UpdateAsync(int id, DataTypeEntryModel model);
        Task DeleteAsync(int id);
    }
}
