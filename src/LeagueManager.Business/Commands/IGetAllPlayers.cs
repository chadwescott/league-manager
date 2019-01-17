using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface IGetAllPlayers
    {
        Player[] Execute();
    }
}
