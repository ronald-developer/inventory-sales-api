using AutoMapper;
using InventorySales.Api.DTO.RoleManager.Models;
using InventorySales.EntityFramework;
using InventorySales.Models.RoleManager;

namespace InventorySales.Api.DTO.RoleManager.Responses
{
    public class PostCreateRoleResponse
    {
        public PostCreateRoleResponse(IMapper mapper, AppRole source)
        {
            Data = mapper.Map<DTORoleModel>(source);
        }
        public DTORoleModel Data { get; set; }
    }
}
