﻿using System;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetPlayerById : IGetPlayerById
    {
        private readonly IResourceMapper<Player, PlayerResource> _mapper;
        private readonly IGetByIdSqlCommand<PlayerResource> _sqlCommand;

        public GetPlayerById(IResourceMapper<Player, PlayerResource> mapper, IGetByIdSqlCommand<PlayerResource> sqlCommand)
        {
            _mapper = mapper;
            _sqlCommand = sqlCommand;
        }

        public Player Execute(Guid id)
        {
            return _mapper.ToModel(_sqlCommand.Execute(id));
        }
    }
}
