using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.PersistCommands
{
    public interface IPersistCommand<in T> where T : IDbContext
    {
        void Execute(T context);
    }
}
