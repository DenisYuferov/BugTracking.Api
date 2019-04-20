using System.Collections;
using System.Collections.Generic;

namespace BugTracking.Api.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository
    {
        IEnumerable<T> AllAsync<T>();

        T GetByIdAsync<T>(int i);
        void InsertAsync<T>(T item);
        void UpdateAsync<T>(T item);
        void DeleteAsync<T>(T item);
        void DeleteByIdAsync<T>(int i);
    }
}
