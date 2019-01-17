
using Microsoft.EntityFrameworkCore;

namespace LeagueManager.DataAccess.Context
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        private readonly string _connectionString;

        protected BaseDbContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public void SetEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {
            Entry(entity).State = state;
        }
    }
}
