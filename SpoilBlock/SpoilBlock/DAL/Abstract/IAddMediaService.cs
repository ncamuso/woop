namespace SpoilBlock.DAL.Abstract
{
    public interface IAddMediaService
    {
        public bool Add(string imdbId, string title, string description, string woopUserId);
    }
}
