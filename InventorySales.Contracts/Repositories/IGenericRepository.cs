using InventorySales.EntityFramework;

namespace InventorySales.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        InventorySalesDbContext GetDbContext();
        Task<T> GetByIdAsync(string key, int id, string[]? navigationProps = null);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(string key, int id);
        Task UpdateAsync(string key, int id, T entity);
        Task<List<T>> GetAllAsync(string[]? navigationProps = null);
        Task<bool> ExistsAsync(string key, int id);
    }
}
