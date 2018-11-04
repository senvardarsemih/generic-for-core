using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PatternForCore.Data.Repositories.Interfaces;

namespace PatternForCore.Data.UOW
{
    public interface IUnitOfWork
    {
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
        /// <returns>The number of objects in an Added, Modified, or Deleted state asynchronously</returns>
        Task<int> CommitAsync();
        /// <returns>Repository</returns>
        IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;
    }
}
