using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetModelById<TM, TR> : IGetModelById<TM>
        where TR : class, IHasId
    {
        private readonly IResourceMapper<TM, TR> _mapper;
        private readonly IGetSqlCommand<TR> _sqlCommand;

        public GetModelById(IResourceMapper<TM, TR> mapper, IGetSqlCommand<TR> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public TM Execute(Guid id)
        {
            return _sqlCommand.Execute(x => x.Where(y => y.Id == id))
                .Select(x => _mapper.ToModel(x))
                .SingleOrDefault();
        }
    }
}
