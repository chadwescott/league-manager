using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands
{
    public interface IDeleteSqlCommand<T>
        where T : class, IHasId
    {
        void Execute(T resource);
    }
}
