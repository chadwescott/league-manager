using System;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetPlayerById : IGetPlayerById
    {
        private readonly IGetByIdSqlCommand<PlayerResource> _sqlCommand;

        public GetPlayerById(IGetByIdSqlCommand<PlayerResource> sqlCommand)
        {
            _sqlCommand = sqlCommand;
        }

        public Player Execute(Guid id)
        {
            return _sqlCommand.Execute(id).ToPlayer();
        }
    }
}
