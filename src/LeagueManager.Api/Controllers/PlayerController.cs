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
    [Route(Routes.Players)]
    public class PlayerController : BaseController
    {
        private readonly IGetModels<Player> _getAllPlayers;
        private readonly IGetModelById<Player> _getPlayerById;
        private readonly ISaveModel<Player> _savePlayer;

        public PlayerController(
            IMapper mapper,
            IGetModels<Player> getAllPlayers,
            IGetModelById<Player> getPlayerById,
            ISaveModel<Player> savePlayer)
            : base(mapper)
        {
            _getAllPlayers = getAllPlayers;
            _getPlayerById = getPlayerById;
            _savePlayer = savePlayer;
        }

        /// <summary>
        /// Returns all the players.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getPlayers", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse[]> GetAllPlayers()
        {
            var players = _getAllPlayers.Execute();
            var response = players.Select(x => Mapper.Map<PlayerResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the player with the player id provided.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Players + "/{playerId}")]
        [SwaggerOperation(OperationId = "getPlayerById", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> GetPlayerById([FromRoute] Guid playerId)
        {
            var player = _getPlayerById.Execute(playerId);
            if (player == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<PlayerResponse>(player));
        }

        /// <summary>
        /// Creates a new player.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(OperationId = "createPlayer", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> CreatePlayer(PlayerRequest request)
        {
            var player = _savePlayer.Execute(Mapper.Map<Player>(request));
            var response = Mapper.Map<PlayerResponse>(player);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the player with the player id provided.
        /// </summary>
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
        public ActionResult<PlayerResponse> UpdatePlayer([FromRoute] Guid playerId, PlayerRequest request)
        {
            var player = Mapper.Map<Player>(request);
            player.Id = playerId;

            player = _savePlayer.Execute(player);
            var response = Mapper.Map<PlayerResponse>(player);
            return new OkObjectResult(response);
        }
    }
}
