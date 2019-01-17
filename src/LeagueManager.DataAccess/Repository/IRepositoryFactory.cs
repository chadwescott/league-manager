using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Repository
{
    public interface IRepositoryFactory<T>
    {
        IRepository<T> CreateRepository(IDbContext context);
    }
}
