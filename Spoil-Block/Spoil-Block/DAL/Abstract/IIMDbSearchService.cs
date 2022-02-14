using Spoil_Block.Models;
using System.Collections.Generic;

namespace Spoil_Block.DAL.Abstract
{
    public interface IIMDbSearchService
    {
        IEnumerable<Medium> GetSearchResults(string search);

    }
}
