using AutoMapper;
using InventorySales.Api.DTO.RoleManager.Models;
using InventorySales.Api.DTO.RoleManager.Requests;
using InventorySales.Models.RoleManager;

namespace InventorySales.Api.MappingProfiles
{
    public class RoleManagerProfile : Profile
    {
        public RoleManagerProfile()
        {
            CreateMap<PostCreateRoleRequest, RoleModel>().ReverseMap();
            CreateMap<PostUpdateRoleRequest, RoleModel>().ReverseMap();            
            CreateMap<RoleModel, DTORoleModel>().ReverseMap();
        }
    }
}
