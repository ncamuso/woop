using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;
using System.Security.Claims;

namespace SpoilBlock.DAL.Concrete
{
    public class AddMediaService : IAddMediaService
    {
        private IMediumRepository _mediaRepository;
        private IWoopUserMediumRepository _woopusermediumRepository;
        private IWoopuserRepository _woopuserRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddMediaService(IMediumRepository mediaRepo, IWoopUserMediumRepository userMediaRepo, IWoopuserRepository woopuserRepo, IHttpContextAccessor httpContextAccessor)
        {
            _mediaRepository = mediaRepo;
            _woopusermediumRepository = userMediaRepo;
            _woopuserRepository = woopuserRepo;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Add(string imdbId, string title, string description)
        {
            var userIdentityId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);



            Woopuser user = _woopuserRepository.GetWoopUserByIdentityId(userIdentityId);
            if (_woopusermediumRepository.GetListOfShowsForUser(user.Id).Where(m => m.Imdbid == imdbId).Any())
                return;

            Medium medium = new Medium { Description = description, Imdbid = imdbId, Title = title };

            if (!_mediaRepository.ExistsByImdbID(imdbId))
            {
                medium = _mediaRepository.AddOrUpdate(medium);
            }

            medium = _mediaRepository.FindByImdbID(imdbId);

            WoopuserMedium woopuserMedium = new WoopuserMedium { BlockageLevel = 0, Media = medium, User = user};

            _woopusermediumRepository.AddOrUpdate(woopuserMedium);
        }
    }
}
