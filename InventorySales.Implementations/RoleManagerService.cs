using InventorySales.Contracts;
using InventorySales.EntityFramework;
using InventorySales.Models.ExceptionTypes;
using InventorySales.Models.RoleManager;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace InventorySales.Implementations
{
    public class RoleManagerService : IRoleManagerService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleManagerService(RoleManager<AppRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public async Task<AppRole> CreateRole(RoleModel roleModel)
        {
            if (roleModel == null)
                throw new BadRequestException("Role cannot be null.");

            if (string.IsNullOrWhiteSpace(roleModel.RoleName))
                throw new BadRequestException("Role name cannot be empty.");

            if (await _roleManager.RoleExistsAsync(roleModel.RoleName))
                throw new BadRequestException("Role already exists.");

            AppRole role = new AppRole
            {
                Name = roleModel.RoleName,
                Description = roleModel.Description,
                IsActive = roleModel.IsActive,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            await _roleManager.CreateAsync(role);

            return role;
        }

        public async Task<AppRole> UpdateRole(Guid id, RoleModel roleModel)
        {
            if (roleModel == null)
                throw new BadRequestException("Role cannot be null.");

            AppRole existingRole = await _roleManager.FindByIdAsync(id.ToString());
            if (existingRole == null)
                throw new NotFoundException(roleModel.RoleName, id);

            existingRole.Name = roleModel.RoleName;
            existingRole.Description = roleModel.Description;
            existingRole.IsActive = roleModel.IsActive;

            existingRole.ConcurrencyStamp = Guid.NewGuid().ToString();

            await _roleManager.UpdateAsync(existingRole);

            return existingRole;
        }

        public async Task DeleteRole(Guid roleId)
        {
            AppRole existingRole = await _roleManager.FindByIdAsync(roleId.ToString());
            if (existingRole == null)
                throw new NotFoundException(roleId);

            existingRole.IsActive = false;

            existingRole.ConcurrencyStamp = Guid.NewGuid().ToString();

            await _roleManager.UpdateAsync(existingRole);
        }
    }
}
