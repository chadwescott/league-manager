using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database.Commands
{
    public interface IGetSqlCommand<T>
        where T : class
    {
        IEnumerable<T> Execute(Func<DbSet<T>, IQueryable<T>> action = null);
    }
}
