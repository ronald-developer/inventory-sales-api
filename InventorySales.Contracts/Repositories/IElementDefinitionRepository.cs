using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Contracts.Repositories
{
    /// <summary>
    /// Defines a repository for managing <see cref="ElementDefinition"/> entities.
    /// </summary>
    /// <remarks>This interface extends <see cref="IGenericRepository{T}"/> to provide generic repository
    /// functionality for <see cref="ElementDefinition"/> objects. It can be used to perform CRUD operations and other
    /// data access tasks specific to <see cref="ElementDefinition"/>.</remarks>
    public interface IElementDefinitionRepository : IGenericRepository<ElementDefinition> { }
}
