using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetTeamsByGameId : IGetTeamsByGameId
    {
        private readonly IMapper _mapper;
        private readonly IQueryDbContext _sqlCommand;

        public GetTeamsByGameId(
            IMapper mapper,
            IQueryDbContext sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public Team[] Execute(Guid gameId)
        {
            Team[] teams = null;
            _sqlCommand.Execute(db =>
                teams = (from gt in db.GameTeams
                join t in db.Teams on gt.TeamId equals t.Id
                where gt.GameId == gameId
                select _mapper.Map<Team>(t)).ToArray()
            );
            return teams;
        }
    }
}
