namespace SpoilBlock.Models
{
    public class IMDbNewShows
    {
        public IEnumerable<IMDbUpComing>? items { get; set; }
        public string? errormessage { get; set; }
    }

}
