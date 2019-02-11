using System;

using LeagueManager.DataAccess.Commands;
using LeagueManager.DataAccess.Context;

namespace LeagueManager.Database.Commands.Impl
{
    internal class GetByIdSqlCommand<T> : RepositoryRead<T, T>, IGetByIdSqlCommand<T>
        where T : class
    {
        public  GetByIdSqlCommand(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        public virtual T Execute(Guid id)
        {
            InvokeRepositoryRead(x => Result = x.GetById(id));

            return Result;
        }
    }
}
