using AutoMapper;
using InventorySales.Api.DTO.Account.Models;
using InventorySales.Api.DTO.Account.Requests;
using InventorySales.Api.DTO.Account.Responses;
using InventorySales.Models.AccountManager;

namespace InventorySales.Api.MappingProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<PostCreateUserRequest, UserModel>().ReverseMap();
            CreateMap<PostLoginRequest, LoginModel>().ReverseMap();
            CreateMap<PostRefreshTokenRequest, TokenModel>().ReverseMap();
            CreateMap<TokenModel, DTOTokenModel>().ReverseMap();
        }
    }
}
