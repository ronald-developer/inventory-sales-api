using InventorySales.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public partial class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories", "core");

            builder.HasKey(i => i.InventoryId);

            builder.Property(i => i.Quantity)
                   .IsRequired();

            builder.HasOne(i => i.Asset)
                   .WithMany()
                   .HasForeignKey(i => i.AssetId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
    }
}
