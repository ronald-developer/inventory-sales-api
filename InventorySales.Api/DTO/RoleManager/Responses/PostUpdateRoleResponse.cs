using AutoMapper;
using InventorySales.Api.DTO.RoleManager.Models;
using InventorySales.EntityFramework;

namespace InventorySales.Api.DTO.RoleManager.Responses
{
    public class PostUpdateRoleResponse
    {
        public PostUpdateRoleResponse(IMapper mapper, AppRole source)
        {
            Data = mapper.Map<DTORoleModel>(source);
        }
        public DTORoleModel Data { get; set; }
    }
}
