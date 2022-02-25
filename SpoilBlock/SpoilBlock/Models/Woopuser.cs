using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpoilBlock.Models
{
    [Table("WOOPUser")]
    public partial class Woopuser
    {
        public Woopuser()
        {
            WoopuserMedia = new HashSet<WoopuserMedium>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IdentityID")]
        public int IdentityId { get; set; }
        [StringLength(30)]
        public string Username { get; set; } = null!;

        [InverseProperty(nameof(WoopuserMedium.User))]
        public virtual ICollection<WoopuserMedium> WoopuserMedia { get; set; }
    }
}
