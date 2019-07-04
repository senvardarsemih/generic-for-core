using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PatternForCore.Core.EFContext;
using PatternForCore.Core.Factory;
using PatternForCore.Core.Repositories.Base;
using PatternForCore.Core.Repositories.Interfaces;

namespace PatternForCore.Core.Uow
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
