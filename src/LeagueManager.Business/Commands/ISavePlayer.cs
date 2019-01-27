using LeagueManager.Business.Models;

namespace LeagueManager.Business.Commands
{
    public interface ISavePlayer
    {
        Player Execute(Player player);
    }
}
