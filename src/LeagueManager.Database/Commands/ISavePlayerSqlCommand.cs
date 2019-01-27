using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands
{
    public interface ISavePlayerSqlCommand
    {
        void Execute(PlayerResource resource);
    }
}
