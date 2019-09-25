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

        /// <summary>
        /// Returns the game with the game id provided.
        /// </summary>
        /// <param name="getGameById"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Games + "/{GameId}")]
        [SwaggerOperation(OperationId = "getGameById", Tags = new[] { Categories.Games })]
        [SwaggerResponse(200, Type = typeof(GameResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameResponse> GetGameById([FromServices] IGetModelById<Game> getGameById, [FromRoute] Guid gameId)
        {
            var game = getGameById.Execute(gameId);
            if (game == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<GameResponse>(game));
        }
        

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.Games)]
        [SwaggerOperation(OperationId = "createGame", Tags = new[] { Categories.Games })]
        [SwaggerResponse(200, Type = typeof(GameResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameResponse> CreateGame([FromServices] ISaveModel<Game> saveGame, GameRequest request)
        {
            var game = saveGame.Execute(Mapper.Map<Game>(request));
            var response = Mapper.Map<GameResponse>(game);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the game with the game id provided.
        /// </summary>
        /// <param name="saveGame"></param>
        /// <param name="gameId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Games + "/{GameId}")]
        [SwaggerOperation(OperationId = "updateGame", Tags = new[] { Categories.Games })]
        [SwaggerResponse(200, Type = typeof(GameResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameResponse> UpdateGame([FromServices] ISaveModel<Game> saveGame,
			[FromRoute] Guid gameId,
			GameRequest request)
        {
            var game = Mapper.Map<Game>(request);
            game.Id = gameId;

            game = saveGame.Execute(game);
            var response = Mapper.Map<GameResponse>(game);
            return new OkObjectResult(response);
        }
    }
}