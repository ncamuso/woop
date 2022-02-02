using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Spoil_Block.Models
{
    [Index(nameof(Imdbid), Name = "Unique_IMDBID", IsUnique = true)]
    public partial class Medium
    {
        public Medium()
        {
            UserMedia = new HashSet<UserMedium>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("IMDBID")]
        public int Imdbid { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [InverseProperty(nameof(UserMedium.Media))]
        public virtual ICollection<UserMedium> UserMedia { get; set; }
    }
}
