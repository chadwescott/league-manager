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
    [Route("/api/" + Routes.Teams)]
    public class TeamController : BaseController
    {
        private readonly IGetAllModels<Team> _getAllTeams;
        private readonly IGetModelById<Team> _getTeamById;
        private readonly IGetPlayersByTeam _getPlayersByTeam;
        private readonly ISaveModel<Team> _saveTeam;

        public TeamController(
            IGetAllModels<Team> getAllTeams,
            IGetModelById<Team> getTeamById,
            IGetPlayersByTeam getPlayersByTeam,
            ISaveModel<Team> saveTeam)
        {
            _getAllTeams = getAllTeams;
            _getTeamById = getTeamById;
            _getPlayersByTeam = getPlayersByTeam;
            _saveTeam = saveTeam;
        }

        [HttpGet]
        [SwaggerOperation(OperationId = "getTeams", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse[]> Get()
        {
            var teams = _getAllTeams.Execute();
            var response = teams.Select(x => x.ToResponse()).ToArray();
            return new OkObjectResult(response);
        }

        [HttpGet]
        [Route("/api/" + Routes.Teams + "/{teamId}")]
        [SwaggerOperation(OperationId = "getTeamById", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> Get([FromRoute] Guid teamId)
        {
            var team = _getTeamById.Execute(teamId);
            if (team == null)
                return new NotFoundResult();

            return new OkObjectResult(team.ToResponse());
        }

        [HttpGet]
        [Route("/api/" + Routes.Teams + "/{teamId}/" + Routes.Players)]
        [SwaggerOperation(OperationId = "getTeamPlayers", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse[]> GetTeamPlayers([FromRoute] Guid teamId)
        {
            var players = _getPlayersByTeam.Execute(teamId);
            var response = players.Select(x => x.ToResponse()).ToArray();
            return new OkObjectResult(response);
        }

        [HttpPost]
        [SwaggerOperation(OperationId = "createTeam", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> Post(TeamRequest request)
        {
            var team = _saveTeam.Execute(request.ToTeam());
            var response = team.ToResponse();
            return new OkObjectResult(response);
        }

        [HttpPut]
        [Route("/api/" + Routes.Teams + "/{TeamId}")]
        [SwaggerOperation(OperationId = "updateTeam", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> Put([FromRoute] Guid TeamId, TeamRequest request)
        {
            var team = request.ToTeam();
            team.EventId = TeamId;

            team = _saveTeam.Execute(team);
            var response = team.ToResponse();
            return new OkObjectResult(response);
        }
    }
}
