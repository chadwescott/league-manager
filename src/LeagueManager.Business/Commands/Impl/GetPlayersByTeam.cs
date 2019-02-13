using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetPlayersByTeam : IGetPlayersByTeam
    {
        private readonly IResourceMapper<Player, PlayerResource> _mapper;
        private readonly IGetSqlCommand<TeamPlayerXrefResource> _sqlCommand;

        public GetPlayersByTeam(
            IResourceMapper<Player, PlayerResource> mapper,
            IGetSqlCommand<TeamPlayerXrefResource> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public Player[] Execute(Guid teamId)
        {
            return _sqlCommand.Execute(x => x.Include(y => y.Player).Where(y => y.TeamId == teamId))
                .Select(x => _mapper.ToModel(x.Player)).ToArray();
        }
    }
}
