using System;

using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetEventById
    {
        Event Execute(Guid id);
    }
}
