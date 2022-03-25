using SpoilBlock.Models;

namespace SpoilBlock.DAL.Abstract
{
    public interface IAddMediaService
    {
        public void Add(string imdbId, string title, string description);
        public void MultiSelectAdd(IEnumerable<IMDbUpComing> list);
    }
}
