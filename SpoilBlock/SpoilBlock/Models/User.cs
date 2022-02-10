using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SpoilBlock.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            UserMedia = new HashSet<UserMedium>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(30)]
        public string Username { get; set; } = null!;

        [InverseProperty(nameof(UserMedium.User))]
        public virtual ICollection<UserMedium> UserMedia { get; set; }
    }
}
