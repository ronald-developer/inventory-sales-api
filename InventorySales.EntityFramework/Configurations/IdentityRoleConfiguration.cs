using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventorySales.EntityFramework.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("Roles", "identity");

            builder.Property(r => r.IsActive).HasDefaultValue(true);

            builder.Property(r => r.Description).HasMaxLength(256).IsRequired(false);
        }
    }
}
