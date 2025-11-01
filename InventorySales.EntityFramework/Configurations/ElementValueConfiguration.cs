using InventorySales.EntityFramework.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public partial class ElementValueConfiguration : IEntityTypeConfiguration<ElementValue>
    {
        public void Configure(EntityTypeBuilder<ElementValue> builder)
        {
            builder.ToTable("ElementValues", "metadata");

            builder.HasKey(ev => ev.ElementValueId);

            builder.Property(ev => ev.EntityName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(ev => ev.Value)
                   .HasMaxLength(250);

            builder.HasOne(ev => ev.ElementDefinition)
                   .WithMany()
                   .HasForeignKey(ev => ev.ElementDefinitionId)                   
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            builder.HasIndex(ev => ev.ElementDefinitionId);
            builder.HasIndex(ev => ev.EntityRecordId);
            builder.HasIndex(ev => ev.EntityName);

        }
    }
}
