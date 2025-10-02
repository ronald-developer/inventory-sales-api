using InventorySales.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public partial class AssetTypeConfiguration : IEntityTypeConfiguration<AssetType>
    {
        public void Configure(EntityTypeBuilder<AssetType> builder)
        {
            builder.ToTable("AssetTypes", "core");

            builder.HasKey(at => at.AssetTypeId);

            builder.Property(at => at.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(at => at.Description)
                   .HasMaxLength(250);

            builder.HasMany(at => at.Assets)
                .WithOne(a => a.AssetType)
                .HasForeignKey(a => a.AssetTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
    }
}
