using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetAllPlayers : IGetAllPlayers
    {
        private readonly IGetAllPlayersSqlCommand _sqlCommand;

        public GetAllPlayers(IGetAllPlayersSqlCommand sqlCommand)
        {
            _sqlCommand = sqlCommand;
        }

        public Player[] Execute()
        {
            _sqlCommand.Execute();
            return _sqlCommand.Result.Select(x => x.ToPlayer()).ToArray();
        }
    }
}
