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
            IMapper mapper,
            IGetModels<Team> getAllTeams,
            IGetModelById<Team> getTeamById,
            IGetPlayersByTeam getPlayersByTeam,
            ISaveModel<Team> saveTeam,
            ISaveModel<TeamPlayer> saveTeamPlayer,
            IDeleteModel<TeamPlayer> deleteTeamPlayer)
            : base(mapper)
        {
            _getAllTeams = getAllTeams;
            _getTeamById = getTeamById;
            _getPlayersByTeam = getPlayersByTeam;
            _saveTeam = saveTeam;
            _saveTeamPlayer = saveTeamPlayer;
            _deleteTeamPlayer = deleteTeamPlayer;
        }

        /// <summary>
        /// Returns all the teams.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(OperationId = "getTeams", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse[]> GetAllTeams()
        {
            var teams = _getAllTeams.Execute();
            var response = teams.Select(x => Mapper.Map<TeamResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the team with the team id provided.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Teams + "/{teamId}")]
        [SwaggerOperation(OperationId = "getTeamById", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> GetTeamById([FromRoute] Guid teamId)
        {
            var team = _getTeamById.Execute(teamId);
            if (team == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<TeamResponse>(team));
        }

        /// <summary>
        /// Returns the players on the team with the team id provided.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
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
            var response = players.Select(x => Mapper.Map<PlayerResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Adds the player with the player id provided to the team with the team id provided.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(OperationId = "createTeam", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> CreateTeam(TeamRequest request)
        {
            var team = _saveTeam.Execute(Mapper.Map<Team>(request));
            var response = Mapper.Map<TeamResponse>(team);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the team with the team id provided.
        /// </summary>
        /// <param name="TeamId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Teams + "/{TeamId}")]
        [SwaggerOperation(OperationId = "updateTeam", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> UpdateTeam([FromRoute] Guid TeamId, TeamRequest request)
        {
            var team = Mapper.Map<Team>(request);
            team.EventId = TeamId;

            team = _saveTeam.Execute(team);
            var response = Mapper.Map<TeamResponse>(team);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Removes the player with the player id provided from the team with the team id provided.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
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
