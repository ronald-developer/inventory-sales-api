using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.RoleManager.Requests
{
    public class PostUpdateRoleRequest
    {
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
