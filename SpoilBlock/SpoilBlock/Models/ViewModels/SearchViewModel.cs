using System.ComponentModel.DataAnnotations;

namespace SpoilBlock.Models.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        [StringLength(50)]
        public string query { get; set; }
        public IEnumerable<IMDbEntry>? resultsList {get; set;}
    }
}
