using SpoilBlock.Models;

namespace SpoilBlock.DAL.Abstract
{
    public interface IMediumRepository : IRepository<Medium>
    {
        public bool ExistsByImdbID(string imdbID);

        public Medium FindByImdbID(string imdbID);
    }
}
