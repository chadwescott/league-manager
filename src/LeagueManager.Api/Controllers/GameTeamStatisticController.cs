using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Commands;
using LeagueManager.Business.Models;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    public class GameTeamStatisticController : ControllerBase
    {
        /// <summary>
        /// Returns all the statistics for a game.
        /// </summary>
        /// <param name="getScores"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Games + "/{gameId}/" + Routes.Statistics)]
        [SwaggerOperation(OperationId = "getGameTeamScores", Tags = new[] { Categories.Statistics })]
        [SwaggerResponse(200, Type = typeof(GameTeamStatisticsResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameTeamStatisticsResponse[]> GetAllScores([FromServices] IGetTeamStatisticsByGameId getScores, [FromRoute] Guid gameId)
        {
            var scores = getScores.Execute(gameId);
            var response = scores.Select(x => Mapper.Map<GameTeamStatisticsResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }
    }
}
