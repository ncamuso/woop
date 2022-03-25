using Microsoft.AspNetCore.Mvc;

namespace SpoilBlock.Models
{
    public class IMDbUpComing
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? fullTitle { get; set; }
        public string? year { get; set; }
        public string? releaseState { get; set; }
        public string? image { get; set; }
        public string? runtimeMins { get; set; }
        public string? runtimeStr { get; set; }
        public string? plot { get; set; }
        public string? contentRating { get; set; }
        public string? imDbRating { get; set; }
        public string? imDbRatingCount { get; set; }
        public string? metacriticRating { get; set; }
        public string? genres { get; set; }
        public IEnumerable<GenreList> genreList { get; set; }
        public string? directors { get; set; }
        public IEnumerable<DirectorList> directorList { get; set; }
        public string? stars { get; set; }
        public IEnumerable<StarList> starList { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(IMDbUpComing)) return false;
            IMDbUpComing other = (IMDbUpComing)obj;
            if (id != other.id) return false;
            return true;
        }

       
        
    }

}
