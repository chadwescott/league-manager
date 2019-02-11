using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;

namespace LeagueManager.Api.Mappers.Requests
{
    public static class EventRequestMapper
    {
        public static Event ToEvent(this EventRequest request)
        {
            return new Event
            {
                Id = request.Id,
                Name = request.Name,
                SeasonId = request.SeasonId,
                StartTime = request.StartTime
            };
        }
    }
}
