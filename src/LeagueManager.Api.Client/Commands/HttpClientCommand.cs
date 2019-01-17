using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LeagueManager.Api.Client.Commands
{
    internal abstract class HttpClientCommand<T>
    {
        private readonly Uri _baseUri;

        protected HttpClientCommand(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        public T Execute()
        {
            using (var client = new HttpClient { BaseAddress = _baseUri })
            {
                var response = ClientAction(client);
                if (response.IsSuccessStatusCode)
                {
                    return HandleSuccessResponse(response);
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            return default(T);
                        default:
                            throw new Exception($"{response.StatusCode} ({response.ReasonPhrase})");
                    }
                }
            }
        }

        protected virtual void BeforeExecute(HttpClient client)
        {
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected abstract HttpResponseMessage ClientAction(HttpClient client);

        protected virtual T HandleSuccessResponse(HttpResponseMessage response)
        {
            return response.Content.ReadAsAsync<T>().Result;
        }
    }
}
