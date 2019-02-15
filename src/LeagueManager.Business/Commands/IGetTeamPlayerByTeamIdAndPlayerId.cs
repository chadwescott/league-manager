using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetTeamPlayerByTeamIdAndPlayerId
    {
        TeamPlayer Execute(Guid teamId, Guid playerId);
    }
}
