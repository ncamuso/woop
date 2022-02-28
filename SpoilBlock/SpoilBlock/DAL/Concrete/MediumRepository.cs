using Microsoft.EntityFrameworkCore;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;

namespace SpoilBlock.DAL.Concrete
{
    public class MediumRepository : Repository<Medium>, IMediumRepository
    {
        public MediumRepository(DbContext ctx) : base(ctx)
        {
        }

        public bool ExistsByImdbID(string imdbID)
        {
            if (_dbSet.SingleOrDefault(m => m.Imdbid == imdbID) == null)
                return false;
            return true;
        }

        public Medium FindByImdbID(string imdbID)
        {
            return _dbSet.SingleOrDefault(m => m.Imdbid == imdbID);
        }
    }
}
