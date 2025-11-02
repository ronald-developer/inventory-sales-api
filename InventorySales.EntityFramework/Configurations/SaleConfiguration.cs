using InventorySales.EntityFramework.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales", "transactions");

            builder.HasKey(s => s.SaleId);

            builder.Property(s => s.SaleDate)
                   .IsRequired();

            builder.Property(s => s.SalePrice)
                   .HasColumnType("decimal(18,4)")
                   .IsRequired();

            builder.Property(s => s.PaymentMethod)
                   .HasMaxLength(50);

            builder.HasOne(s => s.Asset)
                   .WithMany(a => a.Sales)
                   .HasForeignKey(s => s.AssetId);

            builder.HasOne(s => s.Customer)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CustomerId);

            builder.HasIndex(s => s.AssetId);
            builder.HasIndex(s => s.CustomerId);
            builder.HasIndex(s => s.SaleDate);
        }
    }
}
