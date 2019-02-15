using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetModels<TM, TR> : IGetModels<TM>
        where TR: class, IHasId
    {
        protected readonly IResourceMapper<TM, TR> Mapper;
        protected readonly IGetSqlCommand<TR> SqlCommand;

        public GetModels(IResourceMapper<TM, TR> mapper, IGetSqlCommand<TR> sqlCommand)
        {
            Mapper = mapper;
            SqlCommand = sqlCommand;
        }

        protected virtual Func<DbSet<TR>, IQueryable<TR>> DbSetFunction() => null;

        public TM[] Execute()
        {
            return SqlCommand.Execute(DbSetFunction()).Select(x => Mapper.ToModel(x)).ToArray();
        }
    }
}
