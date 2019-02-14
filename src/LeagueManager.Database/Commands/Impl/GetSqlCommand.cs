using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database.Commands.Impl
{
    internal class GetSqlCommand<T> : SqlCommand, IGetSqlCommand<T>
        where T : class
    {
        public GetSqlCommand(IContextFactory contextFactory)
            : base(contextFactory)
        { }

        public IEnumerable<T> Execute(Func<DbSet<T>, IQueryable<T>> action = null)
        {
            var results = new List<T>();

            QueryDatabase(context =>
            {
                var dbSet = context.Set<T>();
                results = action == null ? dbSet.ToList() : action(dbSet).ToList();
            });

            return results;
        }
    }
}
