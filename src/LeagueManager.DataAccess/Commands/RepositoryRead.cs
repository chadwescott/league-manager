using System;

using LeagueManager.DataAccess.Context;
using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.Commands
{
    public abstract class RepositoryRead<TD, TR> : RepositoryCommand
        where TD : class
    {
        protected readonly IRepositoryFactory<TD> RepositoryFactory = new ReadOnlyRepositoryFactory<TD>();

        protected RepositoryRead(IContextFactory<IDbContext> contextFactory)
            : base (contextFactory)
        { }

        public TR Result { get; protected set; }

        protected void InvokeRepositoryRead(Action<IRepository<TD>> action)
        {
            using (var context = ContextFactory.CreateContext())
            {
                var repository = RepositoryFactory.CreateRepository(context);
                action(repository);
            }
        }
    }
}
