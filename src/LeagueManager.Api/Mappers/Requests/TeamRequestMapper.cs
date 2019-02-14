using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;

namespace LeagueManager.Api.Mappers.Requests
{
    public static class TeamRequestMapper
    {
        public static Team ToTeam(this TeamRequest request)
        {
            return new Team
            {
                EventId = request.EventId,
                Name = request.Name,
                TeamNumber = request.TeamNumber,
                Wins = request.Wins,
                Losses = request.Losses
            };
        }
    }
}
