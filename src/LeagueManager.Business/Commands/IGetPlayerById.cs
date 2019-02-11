using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetPlayerById
    {
        Player Execute(Guid id);
    }
}
