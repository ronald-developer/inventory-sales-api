using InventorySales.EntityFramework;
using System.Security.Claims;

namespace InventorySales.Contracts
{
    public interface IJwtManager
    {
        Task<string> GenerateTokenAsync(AppUser user);
        Task<string> CreateRefreshToken(AppUser user);
        ClaimsPrincipal DecodeJwtToken(string token);
    }
}
