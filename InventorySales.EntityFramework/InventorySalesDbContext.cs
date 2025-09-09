
using InventorySales.EntityFramework.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.EntityFramework
{
    public class InventorySalesDbContext : IdentityDbContext<AppUser>
    {
        public InventorySalesDbContext(DbContextOptions options) : base(options)
        {
        }

        // public DbSet<Expense> Expenses { get; set; }
        // public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyBaseConfiguration(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
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

