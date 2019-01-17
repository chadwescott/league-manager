using System;

using LeagueManager.Api.Models.Responses;
using LeagueManager.Api.Client.Commands;

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
    }
}
