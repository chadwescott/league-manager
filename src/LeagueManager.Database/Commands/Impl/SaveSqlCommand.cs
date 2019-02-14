using System;
using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands.Impl
{
    internal class SaveSqlCommand<T> : SqlCommand, ISaveSqlCommand<T>
        where T : class, IHasId
    {
        public SaveSqlCommand(IContextFactory contextFactory)
            : base(contextFactory)
        { }

        public void Execute(T resource)
        {
            QueryDatabase(context =>
            {
                var dbSet = context.Set<T>();

                if (resource.Id == Guid.Empty)
                    dbSet.Add(resource);
                else
                    dbSet.Update(resource);

                context.SaveChanges();
            });
        }
    }
}
