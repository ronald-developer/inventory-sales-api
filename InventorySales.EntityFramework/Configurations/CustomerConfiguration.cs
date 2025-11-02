using InventorySales.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "core");

            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.FirstName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.LastName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.Property(c => c.Phone)
                   .HasMaxLength(20);

            builder.Property(c => c.Address)
                  .HasMaxLength(250);
        }
    }
}
