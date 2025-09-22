using InventorySales.EntityFramework;

namespace InventorySales.Contracts
{
    public interface IJwtManager
    {
        Task<string> GenerateTokenAsync(AppUser user);
        Task<string> CreateRefreshToken(AppUser user);
    }
}
