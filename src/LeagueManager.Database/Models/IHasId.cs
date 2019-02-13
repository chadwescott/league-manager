using System;

namespace LeagueManager.Database.Models
{
    public interface IHasId
    {
        Guid Id { get; set; }
    }
}
