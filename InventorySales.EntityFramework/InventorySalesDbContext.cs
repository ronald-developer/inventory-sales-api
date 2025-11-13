
using InventorySales.EntityFramework.Configurations;
using InventorySales.EntityFramework.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.EntityFramework
{
    public class InventorySalesDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public InventorySalesDbContext(DbContextOptions<InventorySalesDbContext> options) : base(options)
        {
        }

        public DbSet<ElementValue> ElementValues { get; set; }
        public DbSet<MetadataSchemaVersion> MetadataSchemaVersions { get; set; }
        // public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("identity");

            builder.ApplyConfigurationsFromAssembly(typeof(AppUserConfiguration).Assembly);

            builder.ApplyConfiguration(new RoleConfiguration());

            ApplyBaseConfiguration(builder);
        }

        private static void ApplyBaseConfiguration(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("Id")
                        .ValueGeneratedOnAdd();
                }
            }
        }
    }

}

