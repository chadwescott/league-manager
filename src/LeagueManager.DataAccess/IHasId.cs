using System;

namespace LeagueManager.DataAccess
{
    public interface IHasId
    {
        Guid Id { get; set; }
    }
}
