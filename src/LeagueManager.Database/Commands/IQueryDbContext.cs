using System;

namespace LeagueManager.Database.Commands
{
    public interface IQueryDbContext<T> where T: IDbContext
    {
        void Execute(Action<ILeagueManagerContext> action = null);
    }
}
