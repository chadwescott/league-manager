using System.Linq;

using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database.Commands;

namespace LeagueManager.Business.Commands.Impl
{
    internal class GetAllEvents : IGetAllEvents
    {
        private readonly IGetAllEventsSqlCommand _sqlCommand;

        public GetAllEvents(IGetAllEventsSqlCommand sqlCommand)
        {
            _sqlCommand = sqlCommand;
        }

        public Event[] Execute()
        {
            return _sqlCommand.Execute().Select(x => x.ToEvent()).ToArray();
        }
    }
}
