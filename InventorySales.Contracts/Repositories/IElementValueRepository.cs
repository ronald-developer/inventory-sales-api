using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Contracts.Repositories
{
    /// <summary>
    /// Defines a repository for managing <see cref="ElementValue"/> entities, providing methods for data access and
    /// manipulation.
    /// </summary>
    /// <remarks>This interface extends <see cref="IGenericRepository{T}"/> with <see cref="ElementValue"/> as
    /// the entity type,  inheriting all generic repository operations such as adding, updating, deleting, and querying
    /// entities.</remarks>
    public interface IElementValueRepository : IGenericRepository<ElementValue>
    {
        Task<IEnumerable<ElementValue>> GetAllElementValuesByElementDefinitionIdAsync(int elementDefinitionId);
    };

}
