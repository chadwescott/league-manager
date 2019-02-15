using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal class TeamPlayerMapper : IResourceMapper<TeamPlayer, TeamPlayerXrefResource>
    {
        public TeamPlayer ToModel(TeamPlayerXrefResource resource)
        {
            return new TeamPlayer
            {
                Id = resource.Id,
                PlayerId = resource.PlayerId,
                TeamId = resource.TeamId
            };
        }

        public TeamPlayerXrefResource ToResource(TeamPlayer model)
        {
            return new TeamPlayerXrefResource
            {
                Id = model.Id,
                PlayerId = model.PlayerId,
                TeamId = model.TeamId
            };
        }
    }
}
