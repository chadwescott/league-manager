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
    [Route(Routes.Seasons)]
    public class SeasonController : BaseController
    {
        private readonly IGetModels<Season> _getAllSeasons;
        private readonly IGetModelById<Season> _getSeasonById;
        private readonly ISaveModel<Season> _saveSeason;

        public SeasonController(
            IMapper mapper,
            IGetModels<Season> getAllSeasons,
            IGetModelById<Season> getSeasonById,
            ISaveModel<Season> saveSeason)
            : base(mapper)
        {
            _getAllSeasons = getAllSeasons;
            _getSeasonById = getSeasonById;
            _saveSeason = saveSeason;
        }

        /// <summary>
        /// Returns all seasons.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getSeasons", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse[]> GetAllSeasons()
        {
            var seasons = _getAllSeasons.Execute();
            var response = seasons.Select(x => Mapper.Map<SeasonResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the season with the season id provided.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Seasons + "/{seasonId}")]
        [SwaggerOperation(OperationId = "getSeasonById", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> GetSeasonById([FromRoute] Guid seasonId)
        {
            var season = _getSeasonById.Execute(seasonId);
            if (season == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<SeasonResponse>(season));
        }

        /// <summary>
        /// Creates a new season.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(OperationId = "createSeason", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> CreateSeason(SeasonRequest request)
        {
            var season = _saveSeason.Execute(Mapper.Map<Season>(request));
            var response = Mapper.Map<SeasonResponse>(season);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the season with the season id provided.
        /// </summary>
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
        public ActionResult<SeasonResponse> UpdateSeason([FromRoute] Guid seasonId, SeasonRequest request)
        {
            var season = Mapper.Map<Season>(request);
            season.Id = seasonId;

            season = _saveSeason.Execute(season);
            var response = Mapper.Map<SeasonResponse>(season);
            return new OkObjectResult(response);
        }
    }
}
