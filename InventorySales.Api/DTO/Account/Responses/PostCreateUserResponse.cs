using AutoMapper;
using InventorySales.Api.DTO.Account.Models;
using InventorySales.Models.AccountManager;

namespace InventorySales.Api.DTO.Account.Responses
{
    public class PostCreateUserResponse
    {
        public PostCreateUserResponse(string id)
        {
            Data = new DTOCreateUserModel { Id = id };
        }
        public DTOCreateUserModel Data { get; set; }
    }
}
