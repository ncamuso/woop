namespace SpoilBlock.DAL.Abstract
{
    public interface IAddMediaService
    {
        public void Add(string imdbId, string title, string description);
    }
}
