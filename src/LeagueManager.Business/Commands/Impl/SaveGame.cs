using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Commands.Impl
{
    internal class SaveGame : SaveModel<Game, GameResource>
    {
        public SaveGame(IMapper mapper, IGetSqlCommand<GameResource> getCommand, ISaveSqlCommand<GameResource> saveCommand)
            : base(mapper, getCommand, saveCommand)
        { }

        protected override void ValidateRequest(Game model)
        {
            base.ValidateRequest(model);
            if (model.StartTime == null)
                model.StartTime = DateTime.Now;
        }

        protected override void OnBeforeSave(Game model, GameResource resource)
        {
            base.OnBeforeSave(model, resource);
            resource.GameTeams = model.TeamIds?.Select(x => new GameTeamXrefResource
            {
                TeamId = x,
                IntegerStatistics = new List<GameTeamIntegerStatisticsResource>
                {
                    new GameTeamIntegerStatisticsResource
                    {
                        Name = "Score",
                        Value = 0
                    }
                }
            }).ToList();
        }
    }
}
