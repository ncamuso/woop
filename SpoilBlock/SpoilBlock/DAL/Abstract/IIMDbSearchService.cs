using SpoilBlock.Models;
using System.Collections.Generic;

namespace SpoilBlock.DAL.Abstract
{
    public interface IIMDbSearchService
    {
        Task<Tuple<IEnumerable<IMDbEntry>, string?>> GetSearchResultsAsync(string search);
    }
}
