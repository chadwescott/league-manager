using System;

using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Commands
{
    public abstract class RepositorySave<T> : RepositoryChange<T> where T : class, IHasId
    {
        protected RepositorySave(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        public void Execute(T resource)
        {
            InvokeRepositoryAndSave(repository =>
            {
                if (resource.Id == Guid.Empty)
                    repository.Insert(resource);
                else
                    repository.Update(resource);
            });
        }
    }
}
