using AutoMapper;
using InventorySales.Api.DTO.AccountManager.Models;
using InventorySales.Models.AccountManager;

namespace InventorySales.Api.DTO.AccountManager.Responses
{
    public class PostLoginResponse
    {
        public PostLoginResponse(IMapper mapper, TokenModel source)
        {
            Data = mapper.Map<DTOTokenModel>(source);
        }
        public DTOTokenModel Data { get; set; }
    }
}
