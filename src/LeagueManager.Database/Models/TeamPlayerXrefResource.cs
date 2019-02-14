using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("TeamPlayerXref")]
    public class TeamPlayerXrefResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [ForeignKey("TeamId")]
        public TeamResource Team { get; set; }

        [Column("TeamId")]
        public Guid TeamId { get; set; }

        [ForeignKey("PlayerId")]
        public PlayerResource Player { get; set; }

        [Column("PlayerId")]
        public Guid PlayerId { get; set; }

        [Column("NoShow")]
        public bool NoShow { get; set; }
    }
}
