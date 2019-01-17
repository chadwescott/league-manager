using System.Collections.Generic;

using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands
{
    public interface IGetAllPlayersSqlCommand
    {
        IEnumerable<PlayerResource> Result { get; }

        void Execute();
    }
}
