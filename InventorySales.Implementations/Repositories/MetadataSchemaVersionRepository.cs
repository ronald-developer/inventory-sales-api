using InventorySales.Contracts;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework;
using InventorySales.EntityFramework.Metadata;
using InventorySales.Models.Constants;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InventorySales.Implementations.Repositories
{
    public class MetadataSchemaVersionRepository : GenericRepository<MetadataSchemaVersion>, IMetadataSchemaVersionRepository
    {
        private readonly InventorySalesDbContext dbContext;
        private readonly IOperationContext operationContext;

        public MetadataSchemaVersionRepository(InventorySalesDbContext dbContext, IOperationContext operationContext) : base(dbContext, operationContext)
        {
            this.dbContext = dbContext;
            this.operationContext = operationContext;
        }

        public async Task<decimal> GetNextVersionNumber(string entityName, VersionIncrementType incrementType)
        {
            var versions = await dbContext.MetadataSchemaVersions
                .Where(v => v.EntityName == entityName)
                .Select(v => v.Version)
                .ToListAsync();

            if (!versions.Any())
                return 1.0m;

            var maxVersion = versions.Max();
            int major = (int)maxVersion;
            int minor = (int)((maxVersion - major) * 100); // Support up to 2 decimal places

            if (incrementType == VersionIncrementType.Major)
            {
                major += 1;
                minor = 0;
            }
            else // Minor
            {
                minor += 10;
                if (minor >= 100)
                {
                    major += 1;
                    minor = 0;
                }
            }

            return decimal.Parse($"{major}.{minor:D2}");
        }
    }

}
