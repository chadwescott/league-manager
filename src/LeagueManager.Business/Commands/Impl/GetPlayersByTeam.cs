using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetPlayersByTeam : IGetPlayersByTeam
    {
        private readonly IMapper _mapper;
        private readonly IGetSqlCommand<TeamPlayerXrefResource> _sqlCommand;

        public GetPlayersByTeam(
            IMapper mapper,
            IGetSqlCommand<TeamPlayerXrefResource> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public Player[] Execute(Guid teamId)
        {
            return _sqlCommand.Execute(x => x.Include(y => y.Player).Where(y => y.TeamId == teamId))
                .Select(x => _mapper.Map<Player>(x.Player)).ToArray();
        }
    }
}
