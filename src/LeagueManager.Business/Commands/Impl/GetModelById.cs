using System;

using LeagueManager.Business.Mappers;
using LeagueManager.DataAccess;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetModelById<TM, TR> : IGetModelById<TM>
        where TR : class, IHasId
    {
        private readonly IResourceMapper<TM, TR> _mapper;
        private readonly IGetByIdSqlCommand<TR> _sqlCommand;

        public GetModelById(IResourceMapper<TM, TR> mapper, IGetByIdSqlCommand<TR> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public TM Execute(Guid id)
        {
            return _mapper.ToModel(_sqlCommand.Execute(id));
        }
    }
}
