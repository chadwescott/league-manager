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
    public class GameTypeController : ControllerBase
    {
        /// <summary>
        /// Returns all the game types.
        /// </summary>
        /// <param name="getGameTypes"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.GameTypes)]
        [SwaggerOperation(OperationId = "getGameTypes", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(GameTypeResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameTypeResponse[]> GetAllGameTypes([FromServices] IGetModels<GameType> getGameTypes)
        {
            var gameTypes = getGameTypes.Execute();
            var response = gameTypes.Select(x => Mapper.Map<GameTypeResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the game type with the game type id provided.
        /// </summary>
        /// <param name="getGameTypeById"></param>
        /// <param name="gameTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.GameTypes + "/{gameTypeId}")]
        [SwaggerOperation(OperationId = "getGameTypeById", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(GameTypeResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameTypeResponse> GetGameTypeById([FromServices] IGetModelById<GameType> getGameTypeById, [FromRoute] Guid gameTypeId)
        {
            var gameType = getGameTypeById.Execute(gameTypeId);
            if (gameType == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<GameTypeResponse>(gameType));
        }

        /// <summary>
        /// Creates a new gameType.
        /// </summary>
        /// <param name="saveGameType"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.GameTypes)]
        [SwaggerOperation(OperationId = "createGameType", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(GameTypeResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameTypeResponse> CreateGameType([FromServices] ISaveModel<GameType> saveGameType, GameTypeRequest request)
        {
            var gameType = saveGameType.Execute(Mapper.Map<GameType>(request));
            var response = Mapper.Map<GameTypeResponse>(gameType);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the gameType with the gameType id provided.
        /// </summary>
        /// <param name="saveGameType"></param>
        /// <param name="gameTypeId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.GameTypes + "/{gameTypeId}")]
        [SwaggerOperation(OperationId = "updateGameType", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(GameTypeResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<GameTypeResponse> UpdateGameType([FromServices] ISaveModel<GameType> saveGameType,
            [FromRoute] Guid gameTypeId,
            GameTypeRequest request)
        {
            var gameType = Mapper.Map<GameType>(request);
            gameType.Id = gameTypeId;

            gameType = saveGameType.Execute(gameType);
            var response = Mapper.Map<GameTypeResponse>(gameType);
            return new OkObjectResult(response);
        }
    }
}
