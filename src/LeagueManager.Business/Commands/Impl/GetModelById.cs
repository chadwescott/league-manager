using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetModelById<TM, TR> : IGetModelById<TM>
        where TR : class, IHasId
    {
        private readonly IMapper _mapper;
        private readonly IGetSqlCommand<TR> _sqlCommand;

        public GetModelById(IMapper mapper, IGetSqlCommand<TR> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public TM Execute(Guid id)
        {
            return _sqlCommand.Execute(x => x.Where(y => y.Id == id))
                .Select(x => _mapper.Map<TM>(x))
                .SingleOrDefault();
        }
    }
}
