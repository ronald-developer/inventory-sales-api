using InventorySales.EntityFramework.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public partial class ElementDefinitionConfiguration : IEntityTypeConfiguration<ElementDefinition>
    {
        public void Configure(EntityTypeBuilder<ElementDefinition> builder)
        {
            builder.ToTable("ElementDefinitions", "metadata");

            builder.HasKey(e => e.ElementDefinitionId);

            builder.Property(e => e.ElementName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.Length)
                   .IsRequired();

            builder.Property(e => e.IsRequired)
                   .IsRequired();

            builder.Property(e => e.EntityName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne(ed => ed.DataType)
               .WithMany(dt => dt.ElementDefinitions)
               .HasForeignKey(ed => ed.DataTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ed => ed.MetadataSchemaVersion)
                   .WithMany(msv => msv.ElementDefinitions)
                   .HasForeignKey(ed => ed.MetadataSchemaVersionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.IsApproved)
                   .IsRequired();
        }
    }
}
