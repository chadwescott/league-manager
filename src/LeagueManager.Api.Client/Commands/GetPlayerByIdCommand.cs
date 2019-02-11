using System;
using System.Net.Http;

using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Client.Commands
{
    internal class GetPlayerByIdCommand : HttpClientCommand<PlayerResponse>
    {
        private readonly Guid _id;

        public GetPlayerByIdCommand(Uri baseUri, Guid id)
            : base(baseUri)
        {
            _id = id;
        }

        protected override HttpResponseMessage ClientAction(HttpClient client)
        {
            return client.GetAsync($"players/{_id}").Result;
        }
    }
}
