using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetPlayers : GetModels<Player, PlayerResource>, IGetModels<Player>
    {
        public GetPlayers(IMapper mapper, IGetSqlCommand<PlayerResource> sqlCommand)
            : base(mapper, sqlCommand)
        { }

        protected override Func<DbSet<PlayerResource>, IQueryable<PlayerResource>> DbSetFunction()
        {
            return dbSet => dbSet.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
        }
    }
}
