using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetTeamPlayerByTeamIdAndPlayerId : GetModels<TeamPlayer, TeamPlayerXrefResource>, IGetTeamPlayerByTeamIdAndPlayerId
    {
        public GetTeamPlayerByTeamIdAndPlayerId(IResourceMapper<TeamPlayer, TeamPlayerXrefResource> mapper, IGetSqlCommand<TeamPlayerXrefResource> sqlCommand)
            : base(mapper, sqlCommand)
        { }

        public TeamPlayer Execute(Guid teamId, Guid playerId)
        {
            return SqlCommand.Execute(x => x.Where(y => y.TeamId == teamId && y.PlayerId == playerId))
                .Select(x => Mapper.ToModel(x)).SingleOrDefault();
        }
    }
}
