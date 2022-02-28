using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpoilBlock.Models;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;

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

        public virtual Woopuser? GetWoopUserByIdentityId(string identityID)
        {
        }

        public virtual async Task  ListShowsAsync(Woopuser user, int mediaID, int blockageLevel)
        {
            WoopuserMedium coreUser = new WoopuserMedium
            {

                User = user,
                MediaId = mediaID,
                BlockageLevel = blockageLevel
            };
            
            _context.Add(coreUser);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
