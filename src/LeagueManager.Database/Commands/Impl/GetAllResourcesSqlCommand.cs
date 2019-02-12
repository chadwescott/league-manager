using System.Collections.Generic;
using System.Linq;

using LeagueManager.DataAccess.Commands;
using LeagueManager.DataAccess.Context;

namespace LeagueManager.Database.Commands.Impl
{
    internal class GetAllResourcesSqlCommand<T> : RepositoryRead<T, IEnumerable<T>>, IGetAllResourcesSqlCommand<T>
        where T : class
    {
        public GetAllResourcesSqlCommand(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        public IEnumerable<T> Execute()
        {
            InvokeRepositoryRead(r =>
            {
                Result = r.GetAll().ToList();
            });
            return Result;
        }
    }
}
