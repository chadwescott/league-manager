using System;

using LeagueManager.DataAccess.Context;
using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.Commands
{
    public abstract class RepositoryChange<T>: RepositoryCommand where T : class, IHasId
    {
        protected readonly IRepositoryFactory<T> RepositoryFactory = new WritableRepositoryFactory<T>();

        protected RepositoryChange(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        protected void InvokeRepositoryAndSave(Action<IRepository<T>> action)
        {
            using (var context = ContextFactory.CreateContext())
            {
                var repository = RepositoryFactory.CreateRepository(context);
                action(repository);
                context.SaveChanges();
            }
        }
    }
}