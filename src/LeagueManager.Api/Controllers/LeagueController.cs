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
    [Route(Routes.Leagues)]
    public class LeagueController : BaseController
    {
        private readonly IGetModels<League> _getAllLeagues;
        private readonly IGetModelById<League> _getLeagueById;
        private readonly ISaveModel<League> _saveLeague;

        public LeagueController(
            IGetModels<League> getAllLeagues,
            IGetModelById<League> getLeagueById,
            ISaveModel<League> saveLeague)
        {
            _getAllLeagues = getAllLeagues;
            _getLeagueById = getLeagueById;
            _saveLeague = saveLeague;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "getLeagues", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse[]> Get()
        {
            var Leagues = _getAllLeagues.Execute();
            var response = Leagues.Select(x => x.ToResponse()).ToArray();
            return new OkObjectResult(response);
        }

        [HttpGet]
        [Route(Routes.Leagues + "/{LeagueId}")]
        [SwaggerOperation(OperationId = "getLeagueById", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> Get([FromRoute] Guid LeagueId)
        {
            var League = _getLeagueById.Execute(LeagueId);
            if (League == null)
                return new NotFoundResult();

            return new OkObjectResult(League.ToResponse());
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "createLeague", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> Post(LeagueRequest request)
        {
            var League = _saveLeague.Execute(request.ToLeague());
            var response = League.ToResponse();
            return new OkObjectResult(response);
        }

        [HttpPut]
        [Route(Routes.Leagues + "/{LeagueId}")]
        [SwaggerOperation(OperationId = "updateLeague", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> Put([FromRoute] Guid LeagueId, LeagueRequest request)
        {
            var League = request.ToLeague();
            League.Id = LeagueId;

            League = _saveLeague.Execute(League);
            var response = League.ToResponse();
            return new OkObjectResult(response);
        }
    }
}
