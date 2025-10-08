using InventorySales.EntityFramework.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public partial class MetadataSchemaConfiguration : IEntityTypeConfiguration<MetadataSchemaVersion>
    {
        public void Configure(EntityTypeBuilder<MetadataSchemaVersion> builder)
        {
            builder.ToTable("MetadataSchemaVersions", "core");

            builder.HasKey(m => m.MetadataSchemaVersionId);

            builder.Property(m => m.EntityName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Version)
                .HasColumnType("decimal(3,2)")
                .IsRequired();

            builder.Property(m => m.VersionDescription)
                .HasMaxLength(100);

            builder.Property(m => m.IsActive)
                .IsRequired();

            builder.HasMany(m => m.ElementDefinitions)
                .WithOne(e => e.MetadataSchemaVersion)
                .HasForeignKey(e => e.MetadataSchemaVersionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Assets)
                .WithOne(a => a.MetadataSchemaVersion)
                .HasForeignKey(a => a.MetadataSchemaVersionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
