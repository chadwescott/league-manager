using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Commands;
using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route(Routes.Events)]
    public class EventController : BaseController
    {
        private readonly IGetModels<Event> _getAllEvents;
        private readonly IGetModelById<Event> _getEventById;
        private readonly IGetTeamsByEvent _getTeamsByEvent;
        private readonly ISaveModel<Event> _saveEvent;

        public EventController(
            IMapper mapper,
            IGetModels<Event> getAllEvents,
            IGetModelById<Event> getEventById,
            IGetTeamsByEvent getTeamsByEvent,
            ISaveModel<Event> saveEvent)
            : base(mapper)
        {
            _getAllEvents = getAllEvents;
            _getEventById = getEventById;
            _getTeamsByEvent = getTeamsByEvent;
            _saveEvent = saveEvent;
        }

        /// <summary>
        /// Returns all the events.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getEvents", Tags = new[] { Categories.Events })]
        [SwaggerResponse(200, Type = typeof(EventResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse[]> GetAllEvents()
        {
            var events = _getAllEvents.Execute();
            var response = events.Select(x => Mapper.Map<EventResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the event with the event id provided.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Events + "/{eventId}")]
        [SwaggerOperation(OperationId = "getEventById", Tags = new[] { Categories.Events })]
        [SwaggerResponse(200, Type = typeof(EventResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse> GetEventById([FromRoute] Guid eventId)
        {
            var model = _getEventById.Execute(eventId);
            if (model == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<EventResponse>(model));
        }

        /// <summary>
        /// Returns the teams participating in the event with the event id provided.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Events + "/{eventId}/teams")]
        [SwaggerOperation(OperationId = "getTeamsByEventId", Tags = new[] { Categories.Events })]
        [SwaggerResponse(200, Type = typeof(TeamResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse[]> GetTeamsByEventId([FromRoute] Guid eventId)
        {
            var model = _getTeamsByEvent.Execute(eventId);
            if (model == null)
                return new NotFoundResult();

            return new OkObjectResult(model.Select(x => Mapper.Map<TeamResponse>(x)));
        }

        /// <summary>
        /// Creates a new event.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(OperationId = "createEvent", Tags = new[] { Categories.Events })]
        [SwaggerResponse(200, Type = typeof(EventResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse> CreateEvent(EventRequest request)
        {
            var model = _saveEvent.Execute(Mapper.Map<Event>(request));
            var response = Mapper.Map<EventResponse>(model);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the event with the event id provided.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Events + "/{eventId}")]
        [SwaggerOperation(OperationId = "updateEvent", Tags = new[] { Categories.Events })]
        [SwaggerResponse(200, Type = typeof(EventResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<EventResponse> UpdateEvent([FromRoute] Guid eventId, EventRequest request)
        {
            var model = Mapper.Map<Event>(request);
            model.Id = eventId;

            model = _saveEvent.Execute(model);
            var response = Mapper.Map<EventResponse>(model);
            return new OkObjectResult(response);
        }
    }
}
