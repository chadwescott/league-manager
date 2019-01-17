using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Repository
{
    public class ReadOnlyRepositoryFactory<T> : IRepositoryFactory<T> where T : class
    {
        public IRepository<T> CreateRepository(IDbContext context)
        {
            return new ReadOnlyRepository<T>(context);
        }
    }
}
