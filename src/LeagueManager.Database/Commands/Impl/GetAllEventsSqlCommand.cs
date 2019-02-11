using System.Collections.Generic;
using System.Linq;

using LeagueManager.DataAccess.Commands;
using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands.Impl
{
    internal class GetAllEventsSqlCommand : RepositoryRead<EventResource, IEnumerable<EventResource>>, IGetAllEventsSqlCommand
    {
        public GetAllEventsSqlCommand(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        public IEnumerable<EventResource> Execute()
        {
            InvokeRepositoryRead(r =>
            {
                Result = r.GetAll().OrderByDescending(x => x.StartTime).ToList();
            });
            return Result;
        }
    }
}
