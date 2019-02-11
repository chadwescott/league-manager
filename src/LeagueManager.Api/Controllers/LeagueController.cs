using System;

using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route("/api/" + Routes.Leagues)]
    public class LeagueController : BaseController
    {
        //private readonly IGetAllLeagues _getAllLeagues;

        //public LeagueController(IGetAllLeagues getAllLeagues)
        //{
        //    _getAllLeagues = getAllLeagues;
        //}

        /// <summary>
        /// Gets the user with the specified pin.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getLeagues", Tags = new[] { "Leagues" })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse[]> Get()
        {
            //var leagues = _getAllLeagues.Execute();
            //var response = leagues.Select(x => x.ToResponse()).ToArray();
            //return new OkObjectResult(response);
            // TODO: Wire up to back end
            var leagues = new LeagueResponse[]
            {
                new LeagueResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Perinton Community Center Morning Basketball League"
                }
            };
            return new OkObjectResult(leagues);
        }
    }
}
