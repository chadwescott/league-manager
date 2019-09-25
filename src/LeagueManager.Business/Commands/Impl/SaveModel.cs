using System;
using System.Linq;

using AutoMapper;

using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class SaveModel<TM, TR> : ISaveModel<TM>
        where TM : class, IHasId
        where TR : class, IHasId
    {
        private readonly IMapper _mapper;
        private readonly IGetSqlCommand<TR> _getCommand;
        private readonly ISaveSqlCommand<TR> _saveCommand;

        public SaveModel(IMapper mapper, IGetSqlCommand<TR> getCommand, ISaveSqlCommand<TR> saveCommand)
        {
            _mapper = mapper;
            _getCommand = getCommand;
            _saveCommand = saveCommand;
        }

        protected virtual void ValidateRequest(TM model) { }

        protected virtual void OnBeforeSave(TM model, TR resource) { }

        public TM Execute(TM model)
        {
            ValidateRequest(model);
            var resource = _mapper.Map<TR>(model);

            if (model.Id != Guid.Empty && _getCommand.Execute(x => x.Where(y => y.Id == model.Id)) == null)
                throw new ArgumentException("Id provided is invalid", model.Id.ToString());

            OnBeforeSave(model, resource);

            _saveCommand.Execute(resource);
            return _mapper.Map<TM>(resource);
        }
    }
}
