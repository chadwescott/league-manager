using System;
using LeagueManager.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LeagueManager.Api.Controllers
{
    [ApiController]
    [Route("/api/" + Routes.Players)]
    public class TeamController : BaseController
    {
        //private readonly IGetAllTeams _getAllTeams;

        //public TeamController(IGetAllTeams getAllTeams)
        //{
        //    _getAllTeams = getAllTeams;
        //}

        /// <summary>
        /// Gets the user with the specified pin.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/" + Routes.Events + "/{eventId}/" + Routes.Teams)]
        [SwaggerOperation(OperationId = "getTeams", Tags = new[] { "Team" })]
        [SwaggerResponse(200, Type = typeof(TeamResponse[]))]
        [SwaggerResponse(400)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public ActionResult<TeamResponse[]> GetTeamsBySession([FromRoute] Guid eventId)
        {
            //var teams = _getAllTeams.Execute();
            //var response = teams.Select(x => x.ToResponse()).ToArray();
            //return new OkObjectResult(response);
            // TODO: Wire up to back end
            var teams = new TeamResponse[]
            {
                new TeamResponse
                {
                    Id = Guid.NewGuid(),
                    TeamNumber = 1,
                    Name = "Dark",
                    Players = new PlayerResponse[]
                    {
                        new PlayerResponse
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Shane",
                            LastName = "Kenyon"
                        },
                        new PlayerResponse
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Chad",
                            LastName = "Wescott"
                        }
                    }
                },
                new TeamResponse
                {
                    Id = Guid.NewGuid(),
                    TeamNumber = 2,
                    Name = "Light",
                    Players = new PlayerResponse[]
                    {
                        new PlayerResponse
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Nate",
                            LastName = "Stevens"
                        },
                        new PlayerResponse
                        {
                            Id = Guid.NewGuid(),
                            FirstName = "Jason",
                            LastName = "Smith"
                        }
                    }
                }
            };
            return new OkObjectResult(teams);
        }
    }
}