using AutoMapper;
using InventorySales.Api.DTO.Account.Models;
using InventorySales.Models.AccountManager;

namespace InventorySales.Api.DTO.Account.Responses
{
    public class PostRefreshTokenResponse
    {
        public PostRefreshTokenResponse(IMapper mapper, TokenModel source)
        {
            Data = mapper.Map<DTOTokenModel>(source);
        }
        public DTOTokenModel Data { get; set; }
    }
}
