using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("Seasons")]
    public class SeasonResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("LeagueId")]
        public Guid LeagueId { get; set; }

        [ForeignKey("Id")]
        public LeagueResource League { get; set; }

        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("SortOrder")]
        public int SortOrder { get; set; }

        [ForeignKey("SeasonId")]
        public IEnumerable<SeasonTeamXrefResource> SeasonTeams { get; set; }
    }
}
