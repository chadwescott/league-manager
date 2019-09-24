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
    public class PlayerController : ControllerBase
    {
        /// <summary>
        /// Returns all the players.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Players)]
        [SwaggerOperation(OperationId = "getPlayers", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse[]> GetAllPlayers([FromServices] IGetModels<Player> getPlayers)
        {
            var players = getPlayers.Execute();
            var response = players.Select(x => Mapper.Map<PlayerResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the player with the player id provided.
        /// </summary>
        /// <param name="getPlayerById"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Players + "/{playerId}")]
        [SwaggerOperation(OperationId = "getPlayerById", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> GetPlayerById([FromServices] IGetModelById<Player> getPlayerById, [FromRoute] Guid playerId)
        {
            var player = getPlayerById.Execute(playerId);
            if (player == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<PlayerResponse>(player));
        }

        /// <summary>
        /// Returns the leagues  the player belongs to.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Players + "/{playerId}/" + Routes.Leagues)]
        [SwaggerOperation(OperationId = "getPlayerById", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> GetPlayerLeauges([FromServices] IGetLeaguesByPlayer getLeaguesByPlayer, [FromRoute] Guid playerId)
        {
            var leagues = getLeaguesByPlayer.Execute(playerId);
            if (leagues == null)
                return new NotFoundResult();

            var response = leagues.Select(l => Mapper.Map<LeagueResponse>(l)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Creates a new player.
        /// </summary>
        /// <param name="savePlayer"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.Players)]
        [SwaggerOperation(OperationId = "createPlayer", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> CreatePlayer([FromServices]ISaveModel<Player> savePlayer, PlayerRequest request)
        {
            var player = savePlayer.Execute(Mapper.Map<Player>(request));
            var response = Mapper.Map<PlayerResponse>(player);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the player with the player id provided.
        /// </summary>
        /// <param name="savePlayer"></param>
        /// <param name="playerId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Players + "/{playerId}")]
        [SwaggerOperation(OperationId = "updatePlayer", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> UpdatePlayer([FromServices]ISaveModel<Player> savePlayer, [FromRoute] Guid playerId, PlayerRequest request)
        {
            var player = Mapper.Map<Player>(request);
            player.Id = playerId;

            player = savePlayer.Execute(player);
            var response = Mapper.Map<PlayerResponse>(player);
            return new OkObjectResult(response);
        }
    }
}
