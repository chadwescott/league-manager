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
    public class SeasonController : ControllerBase
    {
        /// <summary>
        /// Returns all seasons.
        /// </summary>
        /// <param name="getSeasons"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Seasons)]
        [SwaggerOperation(OperationId = "getSeasons", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse[]> GetAllSeasons([FromServices] IGetModels<Season> getSeasons)
        {
            var seasons = getSeasons.Execute();
            var response = seasons.Select(x => Mapper.Map<SeasonResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the season with the season id provided.
        /// </summary>
        /// <param name="getSeasonById"></param>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Seasons + "/{seasonId}")]
        [SwaggerOperation(OperationId = "getSeasonById", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> GetSeasonById([FromServices] IGetModelById<Season> getSeasonById, [FromRoute] Guid seasonId)
        {
            var season = getSeasonById.Execute(seasonId);
            if (season == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<SeasonResponse>(season));
        }

        /// <summary>
        /// Creates a new season.
        /// </summary>
        /// <param name="saveSeason"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.Seasons)]
        [SwaggerOperation(OperationId = "createSeason", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> CreateSeason([FromServices] ISaveModel<Season> saveSeason, SeasonRequest request)
        {
            var season = saveSeason.Execute(Mapper.Map<Season>(request));
            var response = Mapper.Map<SeasonResponse>(season);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the season with the season id provided.
        /// </summary>
        /// <param name="saveSeason"></param>
        /// <param name="seasonId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Seasons + "/{seasonId}")]
        [SwaggerOperation(OperationId = "updateSeason", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> UpdateSeason([FromServices] ISaveModel<Season> saveSeason, [FromRoute] Guid seasonId, SeasonRequest request)
        {
            var season = Mapper.Map<Season>(request);
            season.Id = seasonId;

            season = saveSeason.Execute(season);
            var response = Mapper.Map<SeasonResponse>(season);
            return new OkObjectResult(response);
        }
    }
}
