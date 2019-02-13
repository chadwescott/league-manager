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
    [Route("/api/" + Routes.Players)]
    public class PlayerController : BaseController
    {
        private readonly IGetAllModels<Player> _getAllPlayers;
        private readonly IGetModelById<Player> _getPlayerById;
        private readonly ISaveModel<Player> _savePlayer;

        public PlayerController(
            IGetAllModels<Player> getAllPlayers,
            IGetModelById<Player> getPlayerById,
            ISaveModel<Player> savePlayer)
        {
            _getAllPlayers = getAllPlayers;
            _getPlayerById = getPlayerById;
            _savePlayer = savePlayer;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "getPlayers", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse[]> Get()
        {
            var players = _getAllPlayers.Execute();
            var response = players.Select(x => x.ToResponse()).ToArray();
            return new OkObjectResult(response);
        }

        [HttpGet]
        [Route("/api/" + Routes.Players + "/{playerId}")]
        [SwaggerOperation(OperationId = "getPlayerById", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> Get([FromRoute] Guid playerId)
        {
            var player = _getPlayerById.Execute(playerId);
            if (player == null)
                return new NotFoundResult();

            return new OkObjectResult(player.ToResponse());
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "createPlayer", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> Post(PlayerRequest request)
        {
            var player = _savePlayer.Execute(request.ToPlayer());
            var response = player.ToResponse();
            return new OkObjectResult(response);
        }

        [HttpPut]
        [Route("/api/" + Routes.Players + "/{playerId}")]
        [SwaggerOperation(OperationId = "updatePlayer", Tags = new[] { Categories.Players })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse> Put([FromRoute] Guid playerId, PlayerRequest request)
        {
            var player = request.ToPlayer();
            player.Id = playerId;

            player = _savePlayer.Execute(player);
            var response = player.ToResponse();
            return new OkObjectResult(response);
        }
    }
}
