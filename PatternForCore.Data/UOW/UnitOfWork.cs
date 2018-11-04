using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PatternForCore.Data.EFContext;
using PatternForCore.Data.Factory;
using PatternForCore.Data.Repositories.Base;
using PatternForCore.Data.Repositories.Interfaces;

namespace PatternForCore.Data.UOW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IDatabaseContext dbContext;

        private Dictionary<Type, object> repos;

        public UnitOfWork(IContextFactory contextFactory)
        {
            dbContext = contextFactory.DbContext;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            if (repos == null)
            {
                repos = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repos.ContainsKey(type))
            {
                repos[type] = new GenericRepository<TEntity>(dbContext);
            }

            return (IGenericRepository<TEntity>)repos[type];
        }

        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            return dbContext.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            return await dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(obj: this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                    dbContext = null;
                }
            }
        }
    }
}
