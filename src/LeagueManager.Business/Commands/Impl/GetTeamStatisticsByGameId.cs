using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetTeamStatisticsByGameId : IGetTeamStatisticsByGameId
    {
        private readonly IMapper _mapper;
        private readonly IQueryDbContext _sqlCommand;

        public GetTeamStatisticsByGameId(
            IMapper mapper,
            IQueryDbContext sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public GameTeamStatistics[] Execute(Guid gameId)
        {
            GameTeamStatistics[] statistics = null;
            _sqlCommand.Execute(db => statistics =
            (from gt in db.GameTeams
             .Include(x => x.DecimalStatistics)
             .Include(x => x.IntegerStatistics)
             .Include(x => x.TimeStatistics)
             where gt.GameId == gameId
             select _mapper.Map<GameTeamStatistics>(gt)).ToArray()
             );

            return statistics;
        }
    }
}
