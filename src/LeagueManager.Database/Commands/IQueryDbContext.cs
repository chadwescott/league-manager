using System;

namespace LeagueManager.Database.Commands
{
    public interface IQueryDbContext
    {
        void Execute(Action<ILeagueManagerContext> action = null);
    }
}
