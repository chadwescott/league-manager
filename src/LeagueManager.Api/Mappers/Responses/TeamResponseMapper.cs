using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class TeamResponseMapper
    {
        public static TeamResponse ToResponse(this Team model)
        {
            return new TeamResponse
            {
                Id = model.Id,
                Name = model.Name,
                TeamNumber = model.TeamNumber,
                Wins = model.Wins,
                Losses = model.Losses,
                Links = new []
                {
                    new LinkResponse
                    {
                        Href = $"/{Routes.Teams}/{model.Id}/{Routes.Players}",
                        MediaType = MediaTypes.Json,
                        Method = Methods.GET,
                        Rel = LinkTypes.PLAYERS
                    }
                }
            };
        }
    }
}
