using System;
using System.Linq;

using LeagueManager.Api.Mappers.Requests;
using LeagueManager.Api.Mappers.Responses;
using LeagueManager.Business.Commands;
using LeagueManager.Domain.Requests;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route("/api/" + Routes.Players)]
    public class PlayerController : BaseController
    {
        private readonly IGetAllPlayers _getAllPlayers;
        private readonly ISavePlayer _savePlayer;

        public PlayerController(
            IGetAllPlayers getAllPlayers,
            ISavePlayer savePlayer)
        {
            _getAllPlayers = getAllPlayers;
            _savePlayer = savePlayer;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(PlayerResponse[]))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<PlayerResponse[]> Get()
        {
            var players = _getAllPlayers.Execute();
            var response = players.Select(x => x.ToResponse()).ToArray();
            return new OkObjectResult(response);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(PlayerResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<PlayerResponse> Post(PlayerRequest request)
        {
            var player = _savePlayer.Execute(request.ToPlayer());
            var response = player.ToResponse();
            return new OkObjectResult(response);
        }

        [HttpPut]
        [Route("/api/" + Routes.Players + "/{playerId}")]
        [ProducesResponseType(200, Type = typeof(PlayerResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
