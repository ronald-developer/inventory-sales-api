using InventorySales.Contracts;
using InventorySales.Contracts.Repositories;
using InventorySales.EntityFramework;
using InventorySales.EntityFramework.Core;
using InventorySales.Models.Constants;
using InventorySales.Models.ExceptionTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventorySales.Implementations.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly InventorySalesDbContext dbContext;
        private readonly IOperationContext operationContext;
        public GenericRepository(InventorySalesDbContext dbContext, IOperationContext operationContext)
        {
            this.dbContext = dbContext;
            this.operationContext = operationContext;
        }


        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await dbContext.AddAsync(entity);

                await dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new InternalServerException(entity.GetType().Name, ex.InnerException?.Message);
            }
        }

        public async Task DeleteAsync(string key, int id)
        {
            T result = await GetByIdAsync(key, id);

            if (result == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            dbContext.Set<T>().Remove(result);

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string key, int id)
        {
            T result = await GetByIdAsync(key, id);

            if (result == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            return result != null;
        }

        public async Task<List<T>> GetAllAsync(string[] navigationProps = null)
        {
            IQueryable<T> query = dbContext.Set<T>().AsNoTracking();

            foreach (string navigationProp in navigationProps ?? [])
            {
                query = query.Include(navigationProp);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(string key, int id, string[] navigationProps = null)
        {

            IQueryable<T> query = dbContext.Set<T>().AsNoTracking();

            // Include navigation properties
            foreach (string navigationProp in navigationProps ?? [])
            {
                query = query.Include(navigationProp);
            }

            // Fetch the entity by its ID
            T result = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, key) == id );

            if (result == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            return result;
        }

        public InventorySalesDbContext GetDbContext()
        {
            return dbContext;
        }

        public async Task UpdateAsync(string key, int id, T entity)
        {
            try
            {
                bool exists = await ExistsAsync(key, id);

                if (!exists)
                {
                    throw new NotFoundException(typeof(T).Name, id);
                }

                dbContext.Update(entity);

                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}
