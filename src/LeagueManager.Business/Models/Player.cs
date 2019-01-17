using System;

using LeagueManager.Database.Models;

namespace LeagueManager.Business.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }
    }

    public static class UserMapper
    {
        public static Player ToPlayer(this PlayerResource resource)
        {
            return resource == null
                ? null
                : new Player
                {
                    Id = resource.Id,
                    FirstName = resource.FirstName,
                    LastName = resource.LastName,
                    NickName = resource.NickName,
                    Email = resource.Email
                };
        }
    }
}
