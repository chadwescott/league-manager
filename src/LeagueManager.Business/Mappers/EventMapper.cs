using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal static class EventMapper
    {
        public static Event ToEvent(this EventResource resource)
        {
            return resource == null
                ? null
                : new Event
                {
                    Id = resource.Id,
                    SeasonId = resource.SeasonId,
                    Name = resource.Name,
                    StartTime = resource.StartTime
                };
        }
        public static EventResource ToEventResource(this Event model)
        {
            return model == null
                ? null
                : new EventResource
                {
                    Id = model.Id,
                    SeasonId = model.SeasonId,
                    Name = model.Name,
                    StartTime = model.StartTime
                };
        }
    }
}
