using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetAllEvents
    {
        Event[] Execute();
    }
}
