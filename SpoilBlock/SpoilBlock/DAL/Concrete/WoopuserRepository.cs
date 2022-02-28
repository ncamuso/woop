using Microsoft.EntityFrameworkCore;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;

namespace SpoilBlock.DAL.Concrete
{
    public class WoopuserRepository : Repository<Woopuser>, IWoopuserRepository
    {
        public WoopuserRepository(DbContext ctx) : base(ctx)
        {
        }

        public Woopuser FindByIdentityId(string identityID)
        {
            return _dbSet.FirstOrDefault(user => user.IdentityId == identityID);
        }

    }
}
