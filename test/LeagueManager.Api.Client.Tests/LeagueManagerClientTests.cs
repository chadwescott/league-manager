using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueManager.Api.Client.Tests
{
    [TestClass]
    [TestCategory(TestCategories.IntegrationTest)]
    public class LeagueManagerClientTests
    {
        private LeagueManagerClient _client;

        [TestInitialize]
        public void Initialize()
        {
            var settings = new LeagueManagerClientSettings
            {
                BaseUrl = "https://localhost:44303/baan/api/100/"
            };

            _client = new LeagueManagerClient(settings);
        }

        [TestMethod]
        public void GetPlayersFromClient_Validation()
        {
            var user = _client.GetPlayers();
            Assert.IsNull(user);
        }
    }
}
