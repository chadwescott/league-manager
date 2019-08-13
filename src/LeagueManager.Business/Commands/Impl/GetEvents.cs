using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetEvents : GetModels<Event, EventResource>, IGetModels<Event>
    {
        public GetEvents(IMapper mapper, IGetSqlCommand<EventResource> sqlCommand)
            : base(mapper, sqlCommand)
        { }

        protected override Func<DbSet<EventResource>, IQueryable<EventResource>> DbSetFunction()
        {
            return dbSet => dbSet.OrderByDescending(x => x.StartTime);
        }
    }
}
