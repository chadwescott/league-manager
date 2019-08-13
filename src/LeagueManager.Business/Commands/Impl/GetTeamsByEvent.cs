using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetTeamsByEvent : IGetTeamsByEvent
    {
        private readonly IMapper _mapper;
        private readonly IGetSqlCommand<TeamResource> _sqlCommand;

        public GetTeamsByEvent(
            IMapper mapper,
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
               .Select(x => _mapper.Map<Team>(x))
               .ToArray();
        }
    }
}
