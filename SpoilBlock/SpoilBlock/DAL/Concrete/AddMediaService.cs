using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;
using System.Security.Claims;

namespace SpoilBlock.DAL.Concrete
{
    public class AddMediaService : IAddMediaService
    {
        private IRepository<Medium> _mediaRepository;
        private IRepository<WoopuserMedium> _woopusermediumRepository;
        private IRepository<Woopuser> _woopuserRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddMediaService(IRepository<Medium> mediaRepo, IRepository<WoopuserMedium> userMediaRepo, IRepository<Woopuser> woopuserRepo, IHttpContextAccessor httpContextAccessor)
        {
            _mediaRepository = mediaRepo;
            _woopusermediumRepository = userMediaRepo;
            _woopuserRepository = woopuserRepo;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool Add(string imdbId, string title, string description)
        {
            var userIdentityId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
        }
    }
}
