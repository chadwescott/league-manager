using System.Collections.Generic;
using System.Linq;

using LeagueManager.DataAccess.Commands;
using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands.Impl
{
    internal class GetAllPlayersSqlCommand : RepositoryRead<PlayerResource, IEnumerable<PlayerResource>>, IGetAllPlayersSqlCommand
    {
        public GetAllPlayersSqlCommand(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        public override void Execute()
        {
            InvokeRepositoryRead(r =>
            {
                Result = r.GetAll().OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            });
        }
    }
}
