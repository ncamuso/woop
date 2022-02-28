using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpoilBlock.Models;
using SpoilBlock.DAL.Abstract;

namespace SpoilBlock.DAL.Concrete
{
    public class WoopuserRepository : Repository<Woopuser>, IWoopuserRepository
    {

        public WoopuserRepository(WOOPDbContext ctx) : base(ctx)
        { }
        public bool Exists(Woopuser user)
        {
            return _dbSet.Any(x => x.AspnetIdentityId == user.AspnetIdentityId && x.Username == user.Username);
        }

        public Woopuser? GetWoopUserByIdentityId(string identityID)
        {
            return _dbSet.Where(u => u.AspnetIdentityId == identityID).FirstOrDefault();
        }
    }
}
