using InventorySales.EntityFramework;
using InventorySales.Models.RoleManager;
using Microsoft.AspNetCore.Identity;

namespace InventorySales.Contracts
{
    public interface IRoleManagerService
    {
        Task<AppRole> Create(RoleModel roleModel);
        Task<AppRole> Update(Guid id, RoleModel roleModel);
        Task Delete(Guid roleId);

    }
}
