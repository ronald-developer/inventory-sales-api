using AutoMapper;
using InventorySales.Api.DTO.Role.Models;
using InventorySales.Api.DTO.Role.Requests;
using InventorySales.Models.RoleManager;

namespace InventorySales.Api.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PostCreateRoleRequest, RoleModel>().ReverseMap();
            CreateMap<PostUpdateRoleRequest, RoleModel>().ReverseMap();            
            CreateMap<RoleModel, DTORoleModel>().ReverseMap();
        }
    }
}
