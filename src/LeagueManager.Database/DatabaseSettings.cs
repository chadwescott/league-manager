using Newtonsoft.Json;

namespace LeagueManager.Database
{
    public class DatabaseSettings
    {
        [JsonProperty("connectionString")]
        public string ConnectionString { get; set; }
    }
}
