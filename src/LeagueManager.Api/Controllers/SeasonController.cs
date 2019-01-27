using System;
using LeagueManager.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(200, Type = typeof(SeasonResponse[]))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<SeasonResponse> Get([FromRoute] Guid seasonId)
        {
            // TODO: Wire up to back end
            var seasons = new SeasonResponse
            {
                Id = seasonId,
                Name = "2019"
            };
            return new OkObjectResult(seasons);
        }
    }
}
