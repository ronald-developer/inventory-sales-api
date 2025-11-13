using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.Constants;

namespace InventorySales.Contracts.Repositories
{
    /// <summary>
    /// Defines a repository interface for managing <see cref="MetadataSchemaVersion"/> entities.
    /// </summary>
    /// <remarks>This interface extends <see cref="IGenericRepository{T}"/> to provide repository
    /// functionality  specifically for <see cref="MetadataSchemaVersion"/> objects. It serves as a contract for 
    /// implementing data access operations related to metadata schema versions.</remarks>
    public interface IMetadataSchemaVersionRepository : IGenericRepository<MetadataSchemaVersion> {
        /// <summary>
        /// Generates the next version number for the specified entity based on the provided increment type.
        /// </summary>
        /// <param name="entityName">The name of the entity for which the version number is being generated. Cannot be null or empty.</param>
        /// <param name="incrementType">The type of version increment to apply, such as major, minor, or patch.</param>
        /// <returns>The next version number as a <see cref="decimal"/> after applying the specified increment.</returns>
        Task<decimal> GetNextVersionNumber(string entityName, VersionIncrementType incrementType);
    }
}
