using System;

using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Commands
{
    public abstract class RepositorySave<T> : RepositoryChange<T> where T : class, IHasId
    {
        protected RepositorySave(IContextFactory<IDbContext> contextFactory, T model)
            : base(contextFactory, model)
        { }

        public override void Execute()
        {
            InvokeRepositoryAndSave(repository =>
            {
                if (Result.Id == Guid.Empty)
                    repository.Insert(Result);
                else
                    repository.Update(Result);
            });
        }
    }
}
