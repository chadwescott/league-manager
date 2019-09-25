using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetTeamStatisticsByGameId
    {
        GameTeamStatistics[] Execute(Guid gameId);
    }
}
