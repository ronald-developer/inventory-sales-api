using InventorySales.EntityFramework;
using InventorySales.Models.RoleManager;
using Microsoft.AspNetCore.Identity;

namespace InventorySales.Contracts
{
    public interface IRoleManagerService
    {
        Task<AppRole> CreateRole(RoleModel roleModel);
        Task<AppRole> UpdateRole(Guid id, RoleModel roleModel);
        Task DeleteRole(Guid roleId);

    }
}
