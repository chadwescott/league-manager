using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class EventResponseMapper
    {
        public static EventResponse ToResponse(this Event model)
        {
            return new EventResponse
            {
                Id = model.Id,
                Name = model.Name,
                StartTime = model.StartTime,
                Links = new LinkResponse[]
                {
                    new LinkResponse
                    {
                        Href = $"/{Routes.Seasons}/{model.SeasonId}",
                        MediaType = MediaTypes.Json,
                        Method = Methods.GET,
                        Rel = LinkTypes.SEASONS
                    }
                }
            };
        }
    }
}
