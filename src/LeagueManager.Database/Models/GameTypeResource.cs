using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("GameTypes")]
    public class GameTypeResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("ScoreSystemId")]
        public Guid ScoreSystemId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("MinimumTeams")]
        public int MinimumTeams { get; set; }

        [Column("MaximumTeams")]
        public int MaximumTeams { get; set; }

        [Column("MinimumTeamSize")]
        public int MinimumTeamSize { get; set; }

        [Column("MaximumTeamSize")]
        public int MaximumTeamSize { get; set; }

        [ForeignKey("ScoreSystemId")]
        public ScoreSystemResource ScoreSystem { get; set; }
    }
}
