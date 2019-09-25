using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetTeamsByGameId
    {
        Team[] Execute(Guid gameId);
    }
}
