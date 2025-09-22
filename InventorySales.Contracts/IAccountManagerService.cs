using InventorySales.Models.AccountManager;
using Microsoft.AspNetCore.Identity;

namespace InventorySales.Contracts
{
    public interface IAccountManagerService
    {
        Task<string> Register(UserModel model);
        Task<TokenModel> Login(LoginModel model);
        Task<string> CreateRefreshToken();
        Task<TokenModel> VerifyRefreshToken(TokenModel request);
    }
}
