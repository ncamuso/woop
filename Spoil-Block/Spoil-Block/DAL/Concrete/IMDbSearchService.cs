using Spoil_Block.DAL.Abstract;
using Spoil_Block.Models;
using System.Collections.Generic;

namespace Spoil_Block.DAL.Concrete
{
    public class IMDbSearchService : IIMDbSearchService
    {
        private readonly string _IMDbApiKey;
        private readonly string _IMDbUrlBase;
        public IMDbSearchService(string IMDbApiKey)
        {
            _IMDbApiKey = IMDbApiKey;
            _IMDbUrlBase = "https://imdb-api.com/en/API/";
        }

        public IEnumerable<Medium> GetSearchResults(string search)
        {
            throw new System.NotImplementedException();
        }
    }
}
