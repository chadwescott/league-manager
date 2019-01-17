using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Commands.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueManager.Database.Tests.Commands.Impl
{
    [TestClass]
    [TestCategory(TestCategories.IntegrationTest)]
    public class GetAllPlayersSqlCommandTests
    {
        [TestMethod]
        public void GetAllPlayers_Validation()
        {
            var command = new GetAllPlayersSqlCommand(TestBootstrapper.Instance.Resolve<IContextFactory<IDbContext>>());
            command.Execute();
            Assert.IsNotNull(command.Result);
        }
    }
}
