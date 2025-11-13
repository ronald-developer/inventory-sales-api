using InventorySales.Contracts;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework;
using InventorySales.EntityFramework.Metadata;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.Implementations.Repositories
{
    public class ElementValueRepository : GenericRepository<ElementValue>, IElementValueRepository
    {
        private readonly InventorySalesDbContext dbContext;
        private readonly IOperationContext operationContext;

        public ElementValueRepository(InventorySalesDbContext dbContext, IOperationContext operationContext) : base(dbContext, operationContext)
        {
            this.dbContext = dbContext;
            this.operationContext = operationContext;
        }

        public async Task<IEnumerable<ElementValue>> GetAllElementValuesByElementDefinitionIdAsync(int elementDefinitionId)
        {            
            IEnumerable<ElementValue> result = await dbContext.ElementValues
                .Where(ev => ev.ElementDefinitionId == elementDefinitionId)
                .ToListAsync();

            return result;
        }
    }
}
