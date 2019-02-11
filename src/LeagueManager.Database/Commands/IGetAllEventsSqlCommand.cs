using System.Collections.Generic;

using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands
{
    public interface IGetAllEventsSqlCommand
    {
        IEnumerable<EventResource> Execute();
    }
}
