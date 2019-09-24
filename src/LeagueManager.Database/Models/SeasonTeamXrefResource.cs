using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("SeasonTeamXref")]
    public class SeasonTeamXrefResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [ForeignKey("SeasonId")]
        public SeasonResource Season { get; set; }

        [Column("SeasonId")]
        public Guid SeasonId { get; set; }

        [ForeignKey("TeamId")]
        public TeamResource Team { get; set; }

        [Column("TeamId")]
        public Guid TeamId { get; set; }
    }
}
