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
    public class TeamController : ControllerBase
    {
        /// <summary>
        /// Returns all the teams.
        /// </summary>
        /// <param name="getTeams"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Teams)]
        [SwaggerOperation(OperationId = "getTeams", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse[]> GetAllTeams([FromServices] IGetModels<Team> getTeams)
        {
            var teams = getTeams.Execute();
            var response = teams.Select(x => Mapper.Map<TeamResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Returns the team with the team id provided.
        /// </summary>
        /// <param name="getTeamById"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Teams + "/{teamId}")]
        [SwaggerOperation(OperationId = "getTeamById", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> GetTeamById([FromServices] IGetModelById<Team> getTeamById, [FromRoute] Guid teamId)
        {
            var team = getTeamById.Execute(teamId);
            if (team == null)
                return new NotFoundResult();

            return new OkObjectResult(Mapper.Map<TeamResponse>(team));
        }

        /// <summary>
        /// Returns the players on the team with the team id provided.
        /// </summary>
        /// <param name="getPlayersByTeam"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Routes.Teams + "/{teamId}/" + Routes.Players)]
        [SwaggerOperation(OperationId = "getTeamPlayers", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(PlayerResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<PlayerResponse[]> GetTeamPlayers([FromServices] IGetPlayersByTeam getPlayersByTeam, [FromRoute] Guid teamId)
        {
            var players = getPlayersByTeam.Execute(teamId);
            var response = players.Select(x => Mapper.Map<PlayerResponse>(x)).ToArray();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Adds the player with the player id provided to the team with the team id provided.
        /// </summary>
        /// <param name="saveTeamPlayer"></param>
        /// <param name="getPlayersByTeam"></param>
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
        public ActionResult<PlayerResponse[]> AddTeamPlayer([FromServices] ISaveModel<TeamPlayer> saveTeamPlayer,
            [FromServices] IGetPlayersByTeam getPlayersByTeam,
            [FromRoute] Guid teamId,
            [FromRoute] Guid playerId)
        {
            var teamPlayer = new TeamPlayer { TeamId = teamId, PlayerId = playerId };
            saveTeamPlayer.Execute(teamPlayer);
            return GetTeamPlayers(getPlayersByTeam, teamId);
        }

        /// <summary>
        /// Creates a new team.
        /// </summary>
        /// <param name="saveTeam"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Routes.Teams)]
        [SwaggerOperation(OperationId = "createTeam", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> CreateTeam([FromServices] ISaveModel<Team> saveTeam, TeamRequest request)
        {
            var team = saveTeam.Execute(Mapper.Map<Team>(request));
            var response = Mapper.Map<TeamResponse>(team);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Updates the team with the team id provided.
        /// </summary>
        /// <param name="saveTeam"></param>
        /// <param name="teamId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(Routes.Teams + "/{TeamId}")]
        [SwaggerOperation(OperationId = "updateTeam", Tags = new[] { Categories.Teams })]
        [SwaggerResponse(200, Type = typeof(TeamResponse))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse> UpdateTeam([FromServices] ISaveModel<Team> saveTeam,
            [FromRoute] Guid teamId,
            TeamRequest request)
        {
            var team = Mapper.Map<Team>(request);
            team.Id = teamId;

            team = saveTeam.Execute(team);
            var response = Mapper.Map<TeamResponse>(team);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Removes the player with the player id provided from the team with the team id provided.
        /// </summary>
        /// <param name="deleteTeamPlayer"></param>
        /// <param name="getPlayersByTeam"></param>
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
        public ActionResult<PlayerResponse[]> DeleteTeamPlayer([FromServices] IDeleteModel<TeamPlayer> deleteTeamPlayer,
            [FromServices] IGetPlayersByTeam getPlayersByTeam,
			[FromRoute] Guid teamId,
			[FromRoute] Guid playerId)
        {
            var teamPlayer = new TeamPlayer { TeamId = teamId, PlayerId = playerId };
            deleteTeamPlayer.Execute(teamPlayer);
            return GetTeamPlayers(getPlayersByTeam, teamId);
        }
    }
}
