using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("GameTeamIntegerStatistics")]
    public class GameTeamIntegerStatisticsResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("GameTeamId")]
        public Guid GameTeamId { get; set; }

        [ForeignKey("GameTeamId")]
        public GameTeamXrefResource GameTeam { get; set; }

        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("Value")]
        public int? Value { get; set; }
    }
}
