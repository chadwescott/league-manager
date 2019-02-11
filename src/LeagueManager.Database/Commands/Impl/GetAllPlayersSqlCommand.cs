using System.Collections.Generic;
using System.Linq;

using LeagueManager.DataAccess.Commands;
using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands.Impl
{
    internal class GetAllPlayersSqlCommand : RepositoryRead<PlayerResource, IEnumerable<PlayerResource>>, IGetAllResourcesSqlCommand<PlayerResource>
    {
        public GetAllPlayersSqlCommand(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        public IEnumerable<PlayerResource> Execute()
        {
            InvokeRepositoryRead(r =>
            {
                Result = r.GetAll().OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            });
            return Result;
        }
    }
}
