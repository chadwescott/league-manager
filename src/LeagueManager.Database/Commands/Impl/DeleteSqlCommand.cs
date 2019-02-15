using System;
using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands.Impl
{
    internal class DeleteSqlCommand<T> : SqlCommand, IDeleteSqlCommand<T>
        where T : class, IHasId
    {
        public DeleteSqlCommand(IContextFactory contextFactory)
            : base(contextFactory)
        { }

        public void Execute(T resource)
        {
            QueryDatabase(context =>
            {
                var dbSet = context.Set<T>();

                if (resource.Id != Guid.Empty)
                {
                    dbSet.Remove(resource);
                    context.SaveChanges();
                }
            });
        }
    }
}
