using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetLeaguesByPlayer
    {
        League[] Execute(Guid playerId);
    }
}
