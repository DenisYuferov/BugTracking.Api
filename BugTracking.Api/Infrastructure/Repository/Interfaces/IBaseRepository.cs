using System.Linq;
using System.Threading.Tasks;

namespace BugTracking.Api.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> All();
        Task<TEntity> GetByIdAsync(uint id);
        Task InsertAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity item);
        Task DeleteByIdAsync(uint id);
    }
}
