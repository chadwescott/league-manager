using System.Collections.Generic;

namespace LeagueManager.Database.Commands
{
    public interface IGetAllResourcesSqlCommand<T>
    {
        IEnumerable<T> Execute();
    }
}
