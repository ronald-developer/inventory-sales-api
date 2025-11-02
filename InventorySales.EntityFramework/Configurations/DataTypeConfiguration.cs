using InventorySales.EntityFramework.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public partial class DataTypeConfiguration : IEntityTypeConfiguration<DataType>
    {
        public void Configure(EntityTypeBuilder<DataType> builder)
        {
            builder.ToTable("DataTypes", "metadata");

            builder.HasKey(dt => dt.DataTypeId);

            builder.Property(dt => dt.TypeName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(dt => dt.TypeValueSample)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasMany(dt => dt.ElementDefinitions)
                   .WithOne(ed => ed.DataType)
                   .HasForeignKey(ed => ed.DataTypeId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
    }
}
