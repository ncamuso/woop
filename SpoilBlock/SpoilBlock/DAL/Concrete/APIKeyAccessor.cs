using SpoilBlock.DAL.Abstract;

namespace SpoilBlock.DAL.Concrete
{
    public class APIKeyAccessor : IAPIKeyAccessor
    {

        public string IMDbKey { get; }

        public APIKeyAccessor(string key)
        {
            IMDbKey = key;
        }

    }
}
