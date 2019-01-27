using System;
using LeagueManager.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route("/api/" + Routes.Events)]
    public class EventController : BaseController
    {
        //private readonly IGetAllEvents _getAllEvents;

        //public EventController(IGetAllEvents getAllEvents)
        //{
        //    _getAllEvents = getAllEvents;
        //}

        /// <summary>
        /// Gets the user with the specified pin.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventResponse[]))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<EventResponse[]> Get()
        {
            //var events = _getAllEvents.Execute();
            //var response = events.Select(x => x.ToResponse()).ToArray();
            //return new OkObjectResult(response);
            // TODO: Wire up to back end
            var events = new EventResponse[]
            {
                new EventResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Tuesday",
                    StartTime = DateTime.Parse("1/29/2019 06:00")
                },
                new EventResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Thursday",
                    StartTime = DateTime.Parse("1/31/2019 06:00")
                }
            };
            return new OkObjectResult(events);
        }
    }
}
