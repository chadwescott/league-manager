using System;
using System.Linq;

using LeagueManager.Api.Mappers.Requests;
using LeagueManager.Api.Mappers.Responses;
using LeagueManager.Business.Commands;
using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route("/api/" + Routes.Events)]
    public class EventController : BaseController
    {
        private readonly IGetAllModels<Event> _getAllEvents;
        private readonly IGetModelById<Event> _getEventById;
        private readonly ISaveModel<Event> _saveEvent;

        public EventController(
            IGetAllModels<Event> getAllEvents,
            IGetModelById<Event> getEventById,
            ISaveModel<Event> saveEvent)
        {
            _getAllEvents = getAllEvents;
            _getEventById = getEventById;
            _saveEvent = saveEvent;
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

        [HttpGet]
        [Route("/api/" + Routes.Events + "/{eventId}")]
        [SwaggerOperation(OperationId = "getEventById", Tags = new[] { "Event" })]
        [SwaggerResponse(200, Type = typeof(EventResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse> Get([FromRoute] Guid eventId)
        {
            var model = _getEventById.Execute(eventId);
            if (model == null)
                return new NotFoundResult();

            return new OkObjectResult(model.ToResponse());
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "createEvent", Tags = new[] { "Event" })]
        [SwaggerResponse(200, Type = typeof(EventResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse> Post(EventRequest request)
        {
            var model = _saveEvent.Execute(request.ToEvent());
            var response = model.ToResponse();
            return new OkObjectResult(response);
        }

        [HttpPut]
        [Route("/api/" + Routes.Events + "/{eventId}")]
        [SwaggerOperation(OperationId = "updateEvent", Tags = new[] { "Event" })]
        [SwaggerResponse(200, Type = typeof(EventResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse> Put([FromRoute] Guid eventId, EventRequest request)
        {
            var model = request.ToEvent();
            model.Id = eventId;

            model = _saveEvent.Execute(model);
            var response = model.ToResponse();
            return new OkObjectResult(response);
        }
    }
}
