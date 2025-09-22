using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InventorySales.EntityFramework
{
    public class InventorySalesDbContextFactory : IDesignTimeDbContextFactory<InventorySalesDbContext>
    {
        public InventorySalesDbContext CreateDbContext(string[] args)
        {
            // Load configuration (from appsettings.json)
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // This is important!
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("InventorySalesDbConnectionString");

            // Build the options
            var optionsBuilder = new DbContextOptionsBuilder<InventorySalesDbContext>();
            optionsBuilder.UseSqlServer(connectionString); // Replace with UseSqlite, UseNpgsql, etc. as needed

            return new InventorySalesDbContext(optionsBuilder.Options);
        }
    }

}

