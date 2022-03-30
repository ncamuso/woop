using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpoilBlock.Models
{
    [Table("WOOPUserMedia")]
    public partial class WoopuserMedium
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int BlockageLevel { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("MediaID")]
        public int MediaId { get; set; }

        [ForeignKey(nameof(MediaId))]
        [InverseProperty(nameof(Medium.WoopuserMedia))]
        public virtual Medium Media { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Woopuser.WoopuserMedia))]
        public virtual Woopuser User { get; set; } = null!;
    }
}
