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
    [Route(Routes.Seasons)]
    public class SeasonController : BaseController
    {
        private readonly IGetModels<Season> _getAllSeasons;
        private readonly IGetModelById<Season> _getSeasonById;
        private readonly ISaveModel<Season> _saveSeason;

        public SeasonController(
            IGetModels<Season> getAllSeasons,
            IGetModelById<Season> getSeasonById,
            ISaveModel<Season> saveSeason)
        {
            _getAllSeasons = getAllSeasons;
            _getSeasonById = getSeasonById;
            _saveSeason = saveSeason;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "getSeasons", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse[]> Get()
        {
            var Seasons = _getAllSeasons.Execute();
            var response = Seasons.Select(x => x.ToResponse()).ToArray();
            return new OkObjectResult(response);
        }

        [HttpGet]
        [Route(Routes.Seasons + "/{SeasonId}")]
        [SwaggerOperation(OperationId = "getSeasonById", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> Get([FromRoute] Guid SeasonId)
        {
            var Season = _getSeasonById.Execute(SeasonId);
            if (Season == null)
                return new NotFoundResult();

            return new OkObjectResult(Season.ToResponse());
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "createSeason", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> Post(SeasonRequest request)
        {
            var Season = _saveSeason.Execute(request.ToSeason());
            var response = Season.ToResponse();
            return new OkObjectResult(response);
        }

        [HttpPut]
        [Route(Routes.Seasons + "/{SeasonId}")]
        [SwaggerOperation(OperationId = "updateSeason", Tags = new[] { Categories.Seasons })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse> Put([FromRoute] Guid SeasonId, SeasonRequest request)
        {
            var Season = request.ToSeason();
            Season.Id = SeasonId;

            Season = _saveSeason.Execute(Season);
            var response = Season.ToResponse();
            return new OkObjectResult(response);
        }
    }
}
