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
    [Route(Routes.Leagues)]
    public class LeagueController : BaseController
    {
        private readonly IGetModels<League> _getAllLeagues;
        private readonly IGetModelById<League> _getLeagueById;
        private readonly ISaveModel<League> _saveLeague;

        public LeagueController(
            IMapper mapper,
            IGetModels<League> getAllLeagues,
            IGetModelById<League> getLeagueById,
            ISaveModel<League> saveLeague)
            : base(mapper)
        {
            _getAllLeagues = getAllLeagues;
            _getLeagueById = getLeagueById;
            _saveLeague = saveLeague;
        }

        /// <summary>
        /// Returns all the leagues.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getLeagues", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse[]> GetAllLeagues()
        {
            var Leagues = _getAllLeagues.Execute();
            var response = Leagues.Select(x => Mapper.Map<LeagueResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the league with the league id provided.
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Leagues + "/{LeagueId}")]
        [SwaggerOperation(OperationId = "getLeagueById", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> GetLeagueById([FromRoute] Guid leagueId)
        {
            var league = _getLeagueById.Execute(leagueId);
            if (league == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<LeagueResponse>(league));
        }

        /// <summary>
        /// Creates a new league.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(OperationId = "createLeague", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> CreateLeague(LeagueRequest request)
        {
            var league = _saveLeague.Execute(Mapper.Map<League>(request));
            var response = Mapper.Map<LeagueResponse>(league);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the league with the league id provided.
        /// </summary>
        /// <param name="LeagueId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Leagues + "/{LeagueId}")]
        [SwaggerOperation(OperationId = "updateLeague", Tags = new[] { Categories.Leagues })]
        [SwaggerResponse(200, Type = typeof(LeagueResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<LeagueResponse> UpdateLeague([FromRoute] Guid LeagueId, LeagueRequest request)
        {
            var league = Mapper.Map<League>(request);
            league.Id = LeagueId;

            league = _saveLeague.Execute(league);
            var response = Mapper.Map<LeagueResponse>(league);
            return new OkObjectResult(response);
        }
    }
}
