using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpoilBlock.Models
{
    public partial class UserMedium
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
        [InverseProperty(nameof(Medium.UserMedia))]
        public virtual Medium Media { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserMedia")]
        public virtual User User { get; set; } = null!;
    }
}
