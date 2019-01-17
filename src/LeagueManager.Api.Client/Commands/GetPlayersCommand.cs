using System;
using System.Net.Http;

using LeagueManager.Api.Models.Responses;

namespace LeagueManager.Api.Client.Commands
{
    internal class GetPlayersCommand : HttpClientCommand<PlayerResponse[]>
    {
        public GetPlayersCommand(Uri baseUri)
            : base(baseUri)
        { }

        protected override HttpResponseMessage ClientAction(HttpClient client)
        {
            return client.GetAsync("players").Result;
        }
    }
}
