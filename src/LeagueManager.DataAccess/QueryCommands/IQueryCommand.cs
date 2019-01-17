using System.Collections.Generic;
using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.QueryCommands
{
    public interface IQueryCommand<out T>
    {
        T Execute(IDbContext context, List<string> includes = null);
    }
}
