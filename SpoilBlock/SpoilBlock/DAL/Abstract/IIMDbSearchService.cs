using SpoilBlock.Models;
using System.Collections.Generic;

namespace SpoilBlock.DAL.Abstract
{
    public interface IIMDbSearchService
    {
        IEnumerable<IMDbEntry> GetSearchResults(string search);
    }
}
