using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal class EventMapper : IResourceMapper<Event, EventResource>
    {
        public Event ToModel(EventResource resource)
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

        public EventResource ToResource(Event model)
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
