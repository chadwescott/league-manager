using System;
using System.Linq;

using LeagueManager.Database.Commands.Impl;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueManager.Database.Tests.Commands.Impl
{
    [TestClass]
    [TestCategory(TestCategories.IntegrationTest)]
    public class GetSqlCommandTests
    {
        private IContextFactory _contextFactory;

        [TestInitialize]
        public void Initialize()
        {
            _contextFactory = TestBootstrapper.Instance.Resolve<IContextFactory>();
        }

        [TestMethod]
        public void GetAllLeaguesIncludingSeasons_Validation()
        {
            var command = new GetSqlCommand<LeagueResource>(_contextFactory);
            var result = command.Execute(x => x.Include(y => y.Seasons));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.All(x => x.Seasons != null));
        }

        [TestMethod]
        public void GetPlayerWithTeams_Validation()
        {
            var command = new GetSqlCommand<PlayerResource>(_contextFactory);
            var result = command.Execute(x => x.Include(y => y.PlayerTeams).ThenInclude(pt => pt.Team));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any(x => x.PlayerTeams.Any(y => y.Team != null)));
        }

        [TestMethod]
        public void GetTeamsWithPlayers_Validation()
        {
            var command = new GetSqlCommand<TeamResource>(_contextFactory);
            var result = command.Execute(x => x.Include(y => y.TeamPlayers).ThenInclude(pt => pt.Player));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any(x => x.TeamPlayers.Any(y => y.Player != null)));
        }

        [TestMethod]
        public void GetTeamByIdWithPlayers_Validation()
        {
            var command = new GetSqlCommand<TeamPlayerXrefResource>(_contextFactory);

            var result = command.Execute(x => x.Include(y => y.Player).Where(y => y.TeamId == new Guid("7D026C66-C015-E911-B707-34F64B38F15C")));
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            Assert.IsTrue(result.All(x => x.Player != null));
        }
    }
}
