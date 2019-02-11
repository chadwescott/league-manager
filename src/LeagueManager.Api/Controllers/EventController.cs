using System.Linq;

using LeagueManager.Api.Mappers.Responses;
using LeagueManager.Business.Commands;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route("/api/" + Routes.Events)]
    public class EventController : BaseController
    {
        private readonly IGetAllEvents _getAllEvents;

        public EventController(IGetAllEvents getAllEvents)
        {
            _getAllEvents = getAllEvents;
        }

        /// <summary>
        /// Gets the user with the specified pin.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getEvents", Tags = new[] { "Event" })]
        [SwaggerResponse(200, Type = typeof(EventResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse[]> Get()
        {
            var events = _getAllEvents.Execute();
            var response = events.Select(x => x.ToResponse()).ToArray();
            return new OkObjectResult(response);
        }
    }
}
