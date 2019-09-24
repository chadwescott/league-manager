using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("GameTeamXref")]
    public class GameTeamXrefResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [ForeignKey("GameId")]
        public GameResource Game { get; set; }

        [Column("GameId")]
        public Guid GameId { get; set; }

        [ForeignKey("TeamId")]
        public TeamResource Team { get; set; }

        [Column("TeamId")]
        public Guid TeamId { get; set; }
    }
}
