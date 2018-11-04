using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PatternForCore.Data.EFContext;
using PatternForCore.Model.Configuration;

namespace PatternForCore.Data.Factory
{
    /// <summary>
    /// context factory for ef
    /// </summary>
    public class ContextFactory : IContextFactory
    {
        private readonly IOptions<ConnectionSettings> _connectionOptions;

        public ContextFactory(IOptions<ConnectionSettings> connectionOptions)
        {
            _connectionOptions = connectionOptions;
        }

        public IDatabaseContext DbContext => new EFContext.DatabaseContext(GetDataContext().Options);

        private DbContextOptionsBuilder<EFContext.DatabaseContext> GetDataContext()
        {
            ValidateDefaultConnection();

            var sqlConnectionBuilder = new SqlConnectionStringBuilder(_connectionOptions.Value.DefaultConnection);

            var contextOptionsBuilder = new DbContextOptionsBuilder<EFContext.DatabaseContext>();

            contextOptionsBuilder.UseSqlServer(sqlConnectionBuilder.ConnectionString);

            return contextOptionsBuilder;
        }

        private void ValidateDefaultConnection()
        {
            if (string.IsNullOrEmpty(_connectionOptions.Value.DefaultConnection))
            {
                throw new ArgumentNullException(nameof(_connectionOptions.Value.DefaultConnection));
            }
        }
    }
}
