using System;
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
                BaseUrl = "http://league-manager.com/api/"
            };

            _client = new LeagueManagerClient(settings);
        }

        [TestMethod]
        public void GetPlayersFromClient_Validation()
        {
            var players = _client.GetPlayers();
            Assert.IsNotNull(players);
        }

        [TestMethod]
        public void GetPlayerByIdFromClient_ValidId()
        {
            var player = _client.GetPlayerById(new Guid("1fde3a6e-4b1e-e911-b709-34f64b38f15c"));
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void GetPlayerByIdFromClient_InvalidId()
        {
            var player = _client.GetPlayerById(Guid.Empty);
            Assert.IsNull(player);
        }
    }
}
