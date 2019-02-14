using System;
using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class SaveModel<TM, TR> : ISaveModel<TM>
        where TM : class, IHasId
        where TR : class, IHasId
    {
        private readonly IResourceMapper<TM, TR> _mapper;
        private readonly IGetSqlCommand<TR> _getCommand;
        private readonly ISaveSqlCommand<TR> _saveCommand;

        public SaveModel(IResourceMapper<TM, TR> mapper, IGetSqlCommand<TR> getCommand, ISaveSqlCommand<TR> saveCommand)
        {
            _mapper = mapper;
            _getCommand = getCommand;
            _saveCommand = saveCommand;
        }

        public TM Execute(TM model)
        {
            var resource = _mapper.ToResource(model);

            if (model.Id != Guid.Empty && _getCommand.Execute(x => x.Where(y => y.Id == model.Id)) == null)
                throw new ArgumentException("Id provided is invalid", model.Id.ToString());

            _saveCommand.Execute(resource);
            return _mapper.ToModel(resource);
        }
    }
}
