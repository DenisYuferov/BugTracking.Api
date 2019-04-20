using System.Collections.Generic;
using BugTracking.Api.Infrastructure.Repository.Interfaces;

namespace BugTracking.Api.Infrastructure.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public IEnumerable<T> AllAsync<T>()
        {
            throw new System.NotImplementedException();
        }

        public T GetByIdAsync<T>(int i)
        {
            throw new System.NotImplementedException();
        }

        public void InsertAsync<T>(T item)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAsync<T>(T item)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAsync<T>(T item)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteByIdAsync<T>(int i)
        {
            throw new System.NotImplementedException();
        }
    }
}
