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
    [Route(Routes.Teams)]
    public class TeamController : BaseController
    {
        private readonly IGetModels<Team> _getAllTeams;
        private readonly IGetModelById<Team> _getTeamById;
        private readonly IGetPlayersByTeam _getPlayersByTeam;
        private readonly ISaveModel<Team> _saveTeam;
        private readonly ISaveModel<TeamPlayer> _saveTeamPlayer;
        private readonly IDeleteModel<TeamPlayer> _deleteTeamPlayer;

        public TeamController(
            IGetModels<Team> getAllTeams,
            IGetModelById<Team> getTeamById,
            IGetPlayersByTeam getPlayersByTeam,
            ISaveModel<Team> saveTeam,
            ISaveModel<TeamPlayer> saveTeamPlayer,
            IDeleteModel<TeamPlayer> deleteTeamPlayer)
        {
            _getAllTeams = getAllTeams;
            _getTeamById = getTeamById;
            _getPlayersByTeam = getPlayersByTeam;
            _saveTeam = saveTeam;
            _saveTeamPlayer = saveTeamPlayer;
            _deleteTeamPlayer = deleteTeamPlayer;
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
        [Route(Routes.Teams + "/{teamId}")]
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
        [Route(Routes.Teams + "/{teamId}/" + Routes.Players)]
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
        [Route(Routes.Teams + "/{teamId}/" + Routes.Players + "/{playerId}")]
        [SwaggerOperation(OperationId = "addTeamPlayer", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse[]> AddTeamPlayer([FromRoute] Guid teamId, [FromRoute] Guid playerId)
        {
            var teamPlayer = new TeamPlayer { TeamId = teamId, PlayerId = playerId };
            _saveTeamPlayer.Execute(teamPlayer);
            return GetTeamPlayers(teamId);
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
        [Route(Routes.Teams + "/{TeamId}")]
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

        [HttpDelete]
        [Route(Routes.Teams + "/{teamId}/" + Routes.Players + "/{playerId}")]
        [SwaggerOperation(OperationId = "deleteTeamPlayer", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse[]> DeleteTeamPlayer([FromRoute] Guid teamId, [FromRoute] Guid playerId)
        {
            var teamPlayer = new TeamPlayer { TeamId = teamId, PlayerId = playerId };
            _deleteTeamPlayer.Execute(teamPlayer);
            return GetTeamPlayers(teamId);
        }
    }
}
