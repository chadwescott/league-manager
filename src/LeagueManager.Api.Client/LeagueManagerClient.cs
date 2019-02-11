using System;

using LeagueManager.Api.Client.Commands;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Client
{
    public class LeagueManagerClient
    {
        private readonly Uri _baseUri;

        public LeagueManagerClient(LeagueManagerClientSettings settings)
        {
            _baseUri = new Uri(settings.BaseUrl);
        }

        public PlayerResponse[] GetPlayers()
        {
            var command = new GetPlayersCommand(_baseUri);
            return command.Execute();
        }

        public PlayerResponse GetPlayerById(Guid id)
        {
            var command = new GetPlayerByIdCommand(_baseUri, id);
            return command.Execute();
        }
    }
}
