using System.Linq;

using LeagueManager.Api.Mappers.Responses;
using LeagueManager.Business.Commands;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route("/api/players")]
    public class PlayerController : BaseController
    {
        private readonly IGetAllPlayers _getAllPlayers;

        public PlayerController(IGetAllPlayers getAllPlayers)
        {
            _getAllPlayers = getAllPlayers;
        }

        /// <summary>
        /// Gets the user with the specified pin.
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
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
    }
}
