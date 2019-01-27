using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class SavePlayer : ISavePlayer
    {
        private readonly ISavePlayerSqlCommand _command;

        public SavePlayer(ISavePlayerSqlCommand command)
        {
            _command = command;
        }

        public Player Execute(Player player)
        {
            var resource = player.ToPlayerResource();
            _command.Execute(resource);
            return resource.ToPlayer();
        }
    }
}
