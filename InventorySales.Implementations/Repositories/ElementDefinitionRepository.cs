using InventorySales.Contracts;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework;
using InventorySales.EntityFramework.Metadata;

namespace InventorySales.Implementations.Repositories
{
    public class ElementDefinitionRepository : GenericRepository<ElementDefinition>, IElementDefinitionRepository
    {
        public ElementDefinitionRepository(InventorySalesDbContext dbContext, IOperationContext operationContext) : base(dbContext, operationContext)
        {
        }
    }
}
