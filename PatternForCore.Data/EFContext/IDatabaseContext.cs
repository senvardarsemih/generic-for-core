using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PatternForCore.Data.EFContext
{
    public interface IDatabaseContext
    {
        /// <returns>set for the specified entity</returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        /// <returns>number of state entries interacted with database</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <returns>number of state entries interacted with database</returns>
        Task<int> SaveChangesAsync(bool confirmAllTransactions, CancellationToken cancellationToken);

        /// <returns>number of state entries interacted with database</returns>
        int SaveChanges();

        /// <returns>number of state entries interacted with database</returns>
        int SaveChanges(bool confirmAllTransactions);
        void Dispose();
    }
}
