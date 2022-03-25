using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;
using SpoilBlock.Models.ViewModels;
using System.Diagnostics;

namespace SpoilBlock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IIMDbNewShowsService _newShowsService;
        private IAddMediaService _addMediaService;
        public HomeController(ILogger<HomeController> logger, IIMDbNewShowsService newShowsService, IAddMediaService addMediaService)
        {
            _logger = logger;
            _newShowsService = newShowsService;
            _addMediaService = addMediaService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new NewShowsViewModel();
            ////if (model.query == null) return View();

            var result =  await _newShowsService.GetNewShowsResult();
            model.resultsList = result.Item1;
            model.errorMessage = result.Item2;

            return View(model);
            //return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}