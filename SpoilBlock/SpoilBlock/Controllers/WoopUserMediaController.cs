using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SpoilBlock.Models;
using SpoilBlock.DAL.Abstract;

namespace SpoilBlock.Controllers
{
    public class WoopUserMediaController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWoopuserRepository _wuRepo;
        private readonly IWoopUserMediumRepository _wuMediaRepo;

        public WoopUserMediaController(UserManager<IdentityUser> userManger, IWoopuserRepository wuRepo , IWoopUserMediumRepository wuMediaRepo)
        {
            _userManager = userManger;
            _wuMediaRepo = wuMediaRepo;
            _wuRepo = wuRepo;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
