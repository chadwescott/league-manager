using Newtonsoft.Json;

namespace LeagueManager.Api.Client
{
    public class LeagueManagerClientSettings
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("idpUrl")]
        public string IdpUrl { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }
    }
}
