using System.Linq;
using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal class TeamMapper : IResourceMapper<Team, TeamResource>
    {
        private IResourceMapper<Player, PlayerResource> _playerMapper;

        public TeamMapper(IResourceMapper<Player, PlayerResource> playerMapper)
        {
            _playerMapper = playerMapper;
        }

        public Team ToModel(TeamResource resource)
        {
            return resource == null
                ? null
                : new Team
                {
                    Id = resource.Id,
                    EventId = resource.EventId,
                    Name = resource.Name,
                    TeamNumber = resource.TeamNumber,
                    Wins = resource.Wins,
                    Losses = resource.Losses,
                    Players = resource.TeamPlayers?.Select(x => _playerMapper.ToModel(x.Player)).ToArray()
                };
        }

        public TeamResource ToResource(Team model)
        {
            return model == null
                ? null
                : new TeamResource
                {
                    Id = model.Id,
                    EventId = model.EventId,
                    Name = model.Name,
                    TeamNumber = model.TeamNumber,
                    Wins = model.Wins,
                    Losses = model.Losses
                };
        }
    }
}
