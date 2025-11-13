using InventorySales.EntityFramework.Core;

namespace InventorySales.Contracts.Repositories
{
    /// <summary>
    /// Defines a repository for managing <see cref="Asset"/> entities, providing methods for data access and
    /// manipulation.
    /// </summary>
    /// <remarks>This interface extends <see cref="IGenericRepository{T}"/> with <see cref="Asset"/> as the
    /// entity type. It is intended to encapsulate data access logic specific to <see cref="Asset"/> entities.</remarks>
    public interface IAssetRepository : IGenericRepository<Asset> { }
}
