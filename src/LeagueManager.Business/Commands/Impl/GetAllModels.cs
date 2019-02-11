using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.DataAccess;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetAllModels<TM, TR> : IGetAllModels<TM>
        where TR: class, IHasId
    {
        private readonly IResourceMapper<TM, TR> _mapper;
        private readonly IGetAllResourcesSqlCommand<TR> _sqlCommand;

        public GetAllModels(IResourceMapper<TM, TR> mapper, IGetAllResourcesSqlCommand<TR> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public TM[] Execute()
        {
            return _sqlCommand.Execute().Select(x => _mapper.ToModel(x)).ToArray();
        }
    }
}
