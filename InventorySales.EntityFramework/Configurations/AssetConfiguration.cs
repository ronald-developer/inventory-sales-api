using InventorySales.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace InventorySales.EntityFramework.Configurations
{
    public partial class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.ToTable("Assets", "core");

            builder.HasKey(a => a.AssetId);

            builder.Property(a => a.BasePrice)
                   .HasColumnType("decimal(18,4)");

            builder.Property(a => a.CreatedByUserId)
                   .IsRequired();

            builder.Property(a => a.CreatedAt)
                   .IsRequired();

            builder.HasOne(a => a.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.CreatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.HasOne(a => a.UpdatedByUser)
                   .WithMany()
                   .HasForeignKey(a => a.UpdatedByUserId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.HasOne(a => a.MetadataSchemaVersion)
                   .WithMany(msv => msv.Assets)
                   .HasForeignKey(a => a.MetadataSchemaVersionId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.HasOne(a => a.AssetType)
                   .WithMany(at => at.Assets)
                   .HasForeignKey(a => a.AssetTypeId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.HasIndex(a => a.AssetTypeId);
            builder.HasIndex(a => a.MetadataSchemaVersionId);
            builder.HasIndex(a => a.CreatedByUserId);
            builder.HasIndex(a => a.UpdatedByUserId);
            builder.HasIndex(a => a.CreatedAt);
        }
    }
}
