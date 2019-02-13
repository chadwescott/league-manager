using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetTeamsByEvent
    {
        Team[] Execute(Guid eventId);
    }
}
