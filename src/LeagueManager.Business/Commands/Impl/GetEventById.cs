using System;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetEventById : IGetEventById
    {
        private readonly IResourceMapper<Event, EventResource> _mapper;
        private readonly IGetByIdSqlCommand<EventResource> _sqlCommand;

        public GetEventById(IResourceMapper<Event, EventResource> mapper, IGetByIdSqlCommand<EventResource> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public Event Execute(Guid id)
        {
            return _mapper.ToModel(_sqlCommand.Execute(id));
        }
    }
}
