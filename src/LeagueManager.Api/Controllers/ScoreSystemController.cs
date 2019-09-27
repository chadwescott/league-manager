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
    public class ScoreSystemController : ControllerBase
    {
        /// <summary>
        /// Returns all the score systems.
        /// </summary>
        /// <param name="getScoreSystems"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.ScoreSystems)]
        [SwaggerOperation(OperationId = "getScoreSystems", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(ScoreSystemResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<ScoreSystemResponse[]> GetAllScoreSystems([FromServices] IGetModels<ScoreSystem> getScoreSystems)
        {
            var scoreSystems = getScoreSystems.Execute();
            var response = scoreSystems.Select(x => Mapper.Map<ScoreSystemResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the score system with the score system id provided.
        /// </summary>
        /// <param name="getScoreSystemById"></param>
        /// <param name="scoreSystemId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.ScoreSystems + "/{scoreSystemId}")]
        [SwaggerOperation(OperationId = "getScoreSystemById", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(ScoreSystemResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<ScoreSystemResponse> GetScoreSystemById([FromServices] IGetModelById<ScoreSystem> getScoreSystemById, [FromRoute] Guid scoreSystemId)
        {
            var scoreSystem = getScoreSystemById.Execute(scoreSystemId);
            if (scoreSystem == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<ScoreSystemResponse>(scoreSystem));
        }

        /// <summary>
        /// Creates a new scoreSystem.
        /// </summary>
        /// <param name="saveScoreSystem"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.ScoreSystems)]
        [SwaggerOperation(OperationId = "createScoreSystem", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(ScoreSystemResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<ScoreSystemResponse> CreateScoreSystem([FromServices] ISaveModel<ScoreSystem> saveScoreSystem, ScoreSystemRequest request)
        {
            var scoreSystem = saveScoreSystem.Execute(Mapper.Map<ScoreSystem>(request));
            var response = Mapper.Map<ScoreSystemResponse>(scoreSystem);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the scoreSystem with the scoreSystem id provided.
        /// </summary>
        /// <param name="saveScoreSystem"></param>
        /// <param name="scoreSystemId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.ScoreSystems + "/{scoreSystemId}")]
        [SwaggerOperation(OperationId = "updateScoreSystem", Tags = new[] { Categories.GameConfiguration })]
        [SwaggerResponse(200, Type = typeof(ScoreSystemResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<ScoreSystemResponse> UpdateScoreSystem([FromServices] ISaveModel<ScoreSystem> saveScoreSystem,
			[FromRoute] Guid scoreSystemId,
			ScoreSystemRequest request)
        {
            var scoreSystem = Mapper.Map<ScoreSystem>(request);
            scoreSystem.Id = scoreSystemId;

            scoreSystem = saveScoreSystem.Execute(scoreSystem);
            var response = Mapper.Map<ScoreSystemResponse>(scoreSystem);
            return new OkObjectResult(response);
        }
    }
}
