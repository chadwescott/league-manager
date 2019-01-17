using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Repository
{
    public class WritableRepositoryFactory<T> : IRepositoryFactory<T> where T: class
    {
        public IRepository<T> CreateRepository(IDbContext context)
        {
            return new Repository<T>(context);
        }
    }
}
