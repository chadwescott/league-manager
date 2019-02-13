using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetAllEvents : GetAllModels<Event, EventResource>, IGetAllModels<Event>
    {
        public GetAllEvents(IResourceMapper<Event, EventResource> mapper, IGetSqlCommand<EventResource> sqlCommand)
            : base(mapper, sqlCommand)
        { }

        protected override Func<DbSet<EventResource>, IQueryable<EventResource>> DbSetFunction()
        {
            return dbSet => dbSet.OrderByDescending(x => x.StartTime);
        }
    }
}
