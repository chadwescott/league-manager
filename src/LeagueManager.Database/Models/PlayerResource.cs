using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("Players")]
    public class PlayerResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("FirstName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("NickName")]
        [MaxLength(50)]
        public string NickName { get; set; }

        [Column("Email")]
        [MaxLength(255)]
        public string Email { get; set; }

        public List<TeamPlayerXrefResource> PlayerTeams { get; set; }
    }
}
