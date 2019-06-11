using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatternForCore.Model.Common;
using PatternForCore.Model.Identity;

namespace PatternForCore.Data.EFContext
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
    {
        /// <summary>
        /// initializes a new instance of DbContext class.
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}