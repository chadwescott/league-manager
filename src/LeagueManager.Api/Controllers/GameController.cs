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
    public class GameController : ControllerBase
    {
        /// <summary>
        /// Returns all the games.
        /// </summary>
        /// <param name="getGames"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Games)]
        [SwaggerOperation(OperationId = "getGames", Tags = new[] { Categories.Games })]
        [SwaggerResponse(200, Type = typeof(GameResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameResponse[]> GetAllGames([FromServices] IGetModels<Game> getGames)
        {
            var games = getGames.Execute();
            var response = games.Select(x => Mapper.Map<GameResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }
    }
}