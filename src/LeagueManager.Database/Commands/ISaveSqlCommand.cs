using LeagueManager.DataAccess;

namespace LeagueManager.Database.Commands
{
    public interface ISaveSqlCommand<T>
        where T : class, IHasId
    {
        void Execute(T resource);
    }
}
