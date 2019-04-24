using System;
using System.Linq;
using System.Threading.Tasks;
using BugTracking.Api.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.Api.Infrastructure.Repository
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity> 
        where TEntity : Models.BaseModelExtended 
        where TContext : DbContext
    {
        protected readonly TContext DbContext;

        public BaseRepository(TContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> All()
        {
            return DbContext.Set<TEntity>(); 
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task InsertAsync(TEntity item)
        {
            var dtNow = DateTime.Now;

            item.CreationDate = dtNow;
            item.ModificationDate = dtNow;

            await DbContext.Set<TEntity>().AddAsync(item);

            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            var dtNow = DateTime.Now;

            item.ModificationDate = dtNow;

            DbContext.Set<TEntity>().Update(item);

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity item)
        {
            DbContext.Set<TEntity>().Remove(item);

            await DbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var item = await GetByIdAsync(id);

            if (item == null) return false;

            await DeleteAsync(item);

            return true;
        }
    }
}
