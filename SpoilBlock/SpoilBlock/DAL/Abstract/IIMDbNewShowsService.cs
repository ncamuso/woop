using SpoilBlock.Models;
using System.Collections.Generic;

namespace SpoilBlock.DAL.Abstract
{
    public interface IIMDbNewShowsService
    {
        IEnumerable<IMDbEntry> GetNewShowsResult();
    }
}
