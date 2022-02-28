using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using SpoilBlock.Models;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models.ViewModels;

namespace SpoilBlock.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWoopuserRepository _wuRepo;
        private readonly IWoopUserMediumRepository _wuMediaRepo;

        public WatchlistController(UserManager<IdentityUser> userManger, IWoopuserRepository wuRepo , IWoopUserMediumRepository wuMediaRepo)
        {
            _userManager = userManger;
            _wuMediaRepo = wuMediaRepo;
            _wuRepo = wuRepo;
        }
        
        public IActionResult Index()
        {
            string? id = _userManager.GetUserId(User);
            Woopuser? wum = null;
            if (id != null)
            { 
                wum = _wuRepo.GetWoopUserByIdentityId(id);
            }

            WatchlistViewModel vm = new WatchlistViewModel()
            {
                HasWoopUser = wum != null,
                Username = wum.Username ?? String.Empty,
                AllShows = _wuMediaRepo.GetListOfShowsForUser(wum.Id)
                //AllShows = _wuRepo.GetListOfShows(_wuMediaRepo.GetListOfShowsForUser(wum.Id), wum)

            };


            return View();
        }
    }
}
