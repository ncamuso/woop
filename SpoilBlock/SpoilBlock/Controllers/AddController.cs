using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.DAL.Concrete;
using SpoilBlock.Models;
using SpoilBlock.Models.ViewModels;
using Newtonsoft.Json;


namespace SpoilBlock.Controllers
{
    public class AddController : Controller
    {
        private readonly IWoopuserRepository _woopUserRepository;
        private readonly IMediumRepository _mediumRepository;
        private readonly IWoopUserMediumRepository _woopUserMediumRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddController(IWoopuserRepository woopuserRepo, IMediumRepository mediumRepo, IWoopUserMediumRepository woopUserMediumRepo, IHttpContextAccessor httpContextAccessor)
        {
            _woopUserRepository = woopuserRepo;
            _mediumRepository = mediumRepo;
            _woopUserMediumRepository = woopUserMediumRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        public async Task<JsonResult> GetCurrentWatchListIDs()
        {
            var currentUser = 
        }
    }
}
