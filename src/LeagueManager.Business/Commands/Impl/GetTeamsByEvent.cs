using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetTeamsByEvent : IGetTeamsByEvent
    {
        private readonly IResourceMapper<Team, TeamResource> _mapper;
        private readonly IGetSqlCommand<TeamResource> _sqlCommand;

        public GetTeamsByEvent(
            IResourceMapper<Team, TeamResource> mapper,
            IGetSqlCommand<TeamResource> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public Team[] Execute(Guid eventId)
        {
            return _sqlCommand.Execute(
                x => x.Where(y => y.EventId == eventId))
               .OrderBy(y => y.TeamNumber)
               .Select(x => _mapper.ToModel(x))
               .ToArray();
        }
    }
}
