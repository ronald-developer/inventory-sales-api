using AutoMapper;
using InventorySales.Api.DTO.AccountManager.Models;
using InventorySales.Api.DTO.AccountManager.Requests;
using InventorySales.Api.DTO.AccountManager.Responses;
using InventorySales.Models.AccountManager;

namespace InventorySales.Api.MappingProfiles
{
    public class AuthManagerProfile : Profile
    {
        public AuthManagerProfile()
        {
            CreateMap<PostCreateUserRequest, UserModel>().ReverseMap();
            CreateMap<PostLoginRequest, LoginModel>().ReverseMap();
            CreateMap<PostRefreshTokenRequest, TokenModel>().ReverseMap();
            CreateMap<TokenModel, DTOTokenModel>().ReverseMap();
        }
    }
}
