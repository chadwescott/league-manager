using System;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class SavePlayer : ISavePlayer
    {
        private readonly IGetByIdSqlCommand<PlayerResource> _getByIdCommand;
        private readonly ISaveSqlCommand<PlayerResource> _saveCommand;

        public SavePlayer(IGetByIdSqlCommand<PlayerResource> getByIdCommand, ISaveSqlCommand<PlayerResource> saveCommand)
        {
            _getByIdCommand = getByIdCommand;
            _saveCommand = saveCommand;
        }

        public Player Execute(Player player)
        {
            var resource = player.ToPlayerResource();

            if (player.Id != Guid.Empty)
            {
                _getByIdCommand.Execute(player.Id);
            }
            _saveCommand.Execute(resource);
            return resource.ToPlayer();
        }
    }
}
