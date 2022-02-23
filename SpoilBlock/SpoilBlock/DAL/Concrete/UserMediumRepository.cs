using SpoilBlock.Models;
using System.Collections.Generic;
using System.Linq;
using SpoilBlock.DAL.Abstract;

namespace SpoilBlock.DAL.Concrete
{
    public class UserMediumRepository : Repository<UserMedium>, IUserMediumRepository
    {
        public UserMediumRepository(WOOPDbContext ctx) : base(ctx) 
        { }
        IEnumerable<Medium> IUserMediumRepository.GetListOfShowsForUser(int id)
        {
            return GetAll().Where(um => um.UserId == id).Select(um => um.MediaId).ToList();
        }
    }
}
