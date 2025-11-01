using InventorySales.Models.AccountManager;

namespace InventorySales.Api.DTO.Account.Models
{
    public class DTOTokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
