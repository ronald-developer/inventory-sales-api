namespace InventorySales.Api.DTO.RoleManager.Models
{
    public class DTORoleModel
    {
        public Guid? Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
