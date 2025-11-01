using System.ComponentModel.DataAnnotations;

namespace InventorySales.Api.DTO.Role.Requests
{
    public class PostCreateRoleRequest
    {
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
