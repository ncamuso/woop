using System.ComponentModel.DataAnnotations;

namespace SpoilBlock.Models.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        [StringLength(50)]
        public string query { get; set; }
        public IEnumerable<IMDbEntry>? resultsList {get; set;}
        public string? errorMessage { get; set; }


        public string? addSelectionId { get; set; }
        public string? addSelectionTitle { get; set; }
        public string? addSelectionDescription { get; set; }
    }
}
