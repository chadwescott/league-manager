using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetLeaguesByPlayer : IGetLeaguesByPlayer
    {
        private readonly IMapper _mapper;
        private readonly IQueryDbContext _sqlCommand;

        public GetLeaguesByPlayer(
            IMapper mapper,
            IQueryDbContext sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public League[] Execute(Guid playerId)
        {
            var leagues = new List<League>();

            _sqlCommand.Execute(db =>
                leagues = (from l in db.Leagues
                join s in db.Seasons on l.Id equals s.LeagueId
                join st in db.SeasonTeams on s.Id equals st.SeasonId
                join t in db.Teams on st.TeamId equals t.Id
                join tp in db.TeamPlayers on t.Id equals tp.TeamId
                where tp.PlayerId == playerId
                select _mapper.Map<League>(l)).ToList()
            );

            return leagues.ToArray();
        }
    }
}
