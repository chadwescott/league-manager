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
    [Route(Routes.Leagues)]
    public class LeagueController : ControllerBase
    {
        /// <summary>
        /// Returns all the leagues.
        /// </summary>
        /// <param name="getLeagues"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getLeagues", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse[]> GetAllLeagues([FromServices] IGetModels<League> getLeagues)
        {
            var Leagues = getLeagues.Execute();
            var response = Leagues.Select(x => Mapper.Map<LeagueResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the league with the league id provided.
        /// </summary>
        /// <param name="getLeagueById"></param>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Leagues + "/{LeagueId}")]
        [SwaggerOperation(OperationId = "getLeagueById", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> GetLeagueById([FromServices] IGetModelById<League> getLeagueById, [FromRoute] Guid leagueId)
        {
            var league = getLeagueById.Execute(leagueId);
            if (league == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<LeagueResponse>(league));
        }
        

        /// <summary>
        /// Creates a new league.
        /// </summary>
        /// <param name="saveLeague"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(OperationId = "createLeague", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> CreateLeague([FromServices] ISaveModel<League> saveLeague, LeagueRequest request)
        {
            var league = saveLeague.Execute(Mapper.Map<League>(request));
            var response = Mapper.Map<LeagueResponse>(league);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the league with the league id provided.
        /// </summary>
        /// <param name="saveLeague"></param>
        /// <param name="leagueId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Leagues + "/{LeagueId}")]
        [SwaggerOperation(OperationId = "updateLeague", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> UpdateLeague([FromServices] ISaveModel<League> saveLeague,
			[FromRoute] Guid leagueId,
			LeagueRequest request)
        {
            var league = Mapper.Map<League>(request);
            league.Id = leagueId;

            league = saveLeague.Execute(league);
            var response = Mapper.Map<LeagueResponse>(league);
            return new OkObjectResult(response);
        }
    }
}
