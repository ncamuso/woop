using SpoilBlock.Models;
using System.Collections.Generic;


namespace SpoilBlock.DAL.Abstract
{
    public interface IUserMediumRepository
    {
        IEnumerable<Medium> GetListOfShowsForUser(int id);
    }
}
