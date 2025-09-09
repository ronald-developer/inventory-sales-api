using Microsoft.AspNetCore.Identity;

namespace InventorySales.EntityFramework
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
