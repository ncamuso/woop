namespace SpoilBlock.Models.IMDb
{
    public class IMDbResult
    {
        public string? searchType { get; set; }
        public string? expression { get; set; }
        public IEnumerable<IMDbEntry>? results {get; set;}
        public string? errormessage { get; set; }
    }
}
