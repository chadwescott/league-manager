using System;

using LeagueManager.Business.Mappers;
using LeagueManager.DataAccess;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class SaveModel<TM, TR> : ISaveModel<TM>
        where TM : class, IHasId
        where TR : class, IHasId
    {
        private readonly IResourceMapper<TM, TR> _mapper;
        private readonly IGetByIdSqlCommand<TR> _getByIdCommand;
        private readonly ISaveSqlCommand<TR> _saveCommand;

        public SaveModel(IResourceMapper<TM, TR> mapper, IGetByIdSqlCommand<TR> getByIdCommand, ISaveSqlCommand<TR> saveCommand)
        {
            _mapper = mapper;
            _getByIdCommand = getByIdCommand;
            _saveCommand = saveCommand;
        }

        public TM Execute(TM model)
        {
            var resource = _mapper.ToResource(model);

            if (model.Id != Guid.Empty && _getByIdCommand.Execute(model.Id) == null)
                throw new ArgumentException("Id provided is invalid", model.Id.ToString());

            _saveCommand.Execute(resource);
            return _mapper.ToModel(resource);
        }
    }
}
