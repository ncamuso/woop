using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;

namespace SpoilBlock.DAL.Concrete
{
    public class AddMediaService : IAddMediaService
    {
        private IRepository<Medium> _mediaRepository;
        private IRepository<WoopuserMedium> _woopusermediumRepository;
        public AddMediaService(IRepository<Medium> mediaRepo, IRepository<WoopuserMedium> userMediaRepo)
        {
            _mediaRepository = mediaRepo;
            _woopusermediumRepository = userMediaRepo;
        }
        public bool Add(string imdbId, string title, string description, string woopUserId)
        {
            throw new NotImplementedException();
        }
    }
}
