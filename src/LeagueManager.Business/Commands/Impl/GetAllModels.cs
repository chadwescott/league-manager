using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetAllModels<TM, TR> : IGetAllModels<TM>
        where TR: class, IHasId
    {
        private readonly IResourceMapper<TM, TR> _mapper;
        private readonly IGetSqlCommand<TR> _sqlCommand;

        public GetAllModels(IResourceMapper<TM, TR> mapper, IGetSqlCommand<TR> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        protected virtual Func<DbSet<TR>, IQueryable<TR>> DbSetFunction() => null;

        public TM[] Execute()
        {
            return _sqlCommand.Execute(DbSetFunction()).Select(x => _mapper.ToModel(x)).ToArray();
        }
    }
}
