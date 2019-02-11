using System;

namespace LeagueManager.Database.Commands
{
    public interface IGetByIdSqlCommand<T>
    {
        T Execute(Guid id);
    }
}
