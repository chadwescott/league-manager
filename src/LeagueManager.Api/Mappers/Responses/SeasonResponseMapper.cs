using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class SeasonResponseMapper
    {
        public static SeasonResponse ToResponse(this Season model)
        {
            return new SeasonResponse
            {
                Id = model.Id,
                Name = model.Name,
                SortOrder = model.SortOrder,
                Links = new LinkResponse[]
                {
                    new LinkResponse
                    {
                        Href = $"/{Routes.Leagues}/{model.LeagueId}",
                        MediaType = MediaTypes.Json,
                        Method = Methods.GET,
                        Rel = LinkTypes.LEAGUES
                    }
                }
            };
        }
    }
}
