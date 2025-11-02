using InventorySales.EntityFramework.Core;

namespace InventorySales.Contracts.Repositories
{
    /// <summary>
    /// Defines a repository for managing <see cref="AssetType"/> entities.
    /// </summary>
    /// <remarks>This interface extends <see cref="IGenericRepository{T}"/> to provide generic repository
    /// functionality for <see cref="AssetType"/> objects. It can be used to perform CRUD operations and other data
    /// access tasks specific to <see cref="AssetType"/>.</remarks>
    public interface IAssetTypeRepository : IGenericRepository<AssetType> { }
}
