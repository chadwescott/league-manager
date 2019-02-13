using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetPlayersByTeam
    {
        Player[] Execute(Guid teamId);
    }
}
