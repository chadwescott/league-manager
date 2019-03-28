using AutoMapper;

using LeagueManager.Business.Exceptions;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class DeleteTeamPlayer : IDeleteModel<TeamPlayer>
    {
        private readonly IGetTeamPlayerByTeamIdAndPlayerId _getTeamPlayers;
        private readonly IDeleteSqlCommand<TeamPlayerXrefResource> _deleteTeamPlayer;

        public DeleteTeamPlayer(
            IGetTeamPlayerByTeamIdAndPlayerId getTeamPlayers,
            IDeleteSqlCommand<TeamPlayerXrefResource> deleteTeamPlayer,
            IMapper mapper)
        {
            _getTeamPlayers = getTeamPlayers;
            _deleteTeamPlayer = deleteTeamPlayer;
        }

        public void Execute(TeamPlayer model)
        {
            var teamPlayer = _getTeamPlayers.Execute(model.TeamId, model.PlayerId);
            if (teamPlayer == null)
                throw new ModelNotFoundException($"No team player exists with TeamId: {model.TeamId} and PlayerId: {model.PlayerId}");

            _deleteTeamPlayer.Execute(Mapper.Map<TeamPlayerXrefResource>(teamPlayer));
        }
    }
}
