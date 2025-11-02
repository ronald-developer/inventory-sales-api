using AutoMapper;
using InventorySales.Api.DTO.Role.Models;
using InventorySales.EntityFramework;

namespace InventorySales.Api.DTO.Role.Responses
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
