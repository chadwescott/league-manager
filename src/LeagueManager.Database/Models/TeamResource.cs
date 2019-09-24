using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("Teams")]
    public class TeamResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<TeamPlayerXrefResource> TeamPlayers { get; set; }
    }
}
