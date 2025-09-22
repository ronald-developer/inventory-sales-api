using Microsoft.AspNetCore.Identity;

namespace InventorySales.EntityFramework
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base()
        {
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
