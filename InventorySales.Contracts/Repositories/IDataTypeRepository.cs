using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Contracts.Repositories
{
    /// <summary>
    /// Defines a repository for managing <see cref="DataType"/> entities, providing methods for data access and
    /// manipulation.
    /// </summary>
    /// <remarks>This interface extends <see cref="IGenericRepository{T}"/> with <see cref="DataType"/> as the
    /// entity type. It is intended to encapsulate data access logic specific to <see cref="DataType"/>
    /// entities.</remarks>
    public interface IDataTypeRepository : IGenericRepository<DataType> { }
}
