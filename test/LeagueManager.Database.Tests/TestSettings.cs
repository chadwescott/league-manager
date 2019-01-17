using System.IO;

using Microsoft.Extensions.Configuration;

namespace LeagueManager.Database.Tests
{
    public class TestSettings
    {
        public DatabaseSettings Settings { get; private set; }

        public TestSettings()
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = configBuilder.Build();
            Settings = new DatabaseSettings();
            config.Bind("Database", Settings);
        }
    }
}
