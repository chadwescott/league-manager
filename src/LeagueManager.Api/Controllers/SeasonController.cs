using System;

using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    public class SeasonController : BaseController
    {
        //private readonly IGetSeasonById _getSeasonById;

        //public SeasonController(IGetSeasonById getSeasonById)
        //{
        //    _getSeasonById = getSeasonById;
        //}

        /// <summary>
        /// Gets the user with the specified pin.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/" + Routes.Seasons + "/{seasonId}")]
        [SwaggerOperation(OperationId = "getSeasons", Tags = new[] { "Season" })]
        [SwaggerResponse(200, Type = typeof(SeasonResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<SeasonResponse[]> Get([FromRoute] Guid seasonId)
        {
            // TODO: Wire up to back end
            var seasons = new []
            {
                new SeasonResponse
                {
                    Id = seasonId,
                    Name = "2019"
                }
            };
            return new OkObjectResult(seasons);
        }
    }
}
