using SpoilBlock.Models;
using System.Collections.Generic;


namespace SpoilBlock.DAL.Abstract
{
    public interface IWoopUserMediumRepository
    {
        IEnumerable<Medium> GetListOfShowsForUser(int id);
    }
}
