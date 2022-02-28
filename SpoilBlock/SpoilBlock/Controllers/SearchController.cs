using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models.ViewModels;

namespace SpoilBlock.Controllers
{
    public class SearchController : Controller
    {
        private IIMDbSearchService _searchService;
        private IAddMediaService _addMediaService;

        public SearchController(IIMDbSearchService searchService, IAddMediaService addService)
        {
            _searchService = searchService;
            _addMediaService = addService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Search(SearchViewModel model)
        {
            if (model.query == null) return View();

            model.resultsList = _searchService.GetSearchResults(model.query);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(SearchViewModel model)
        {

            try
            {
                _addMediaService.Add(model.addSelectionId, model.addSelectionTitle, model.addSelectionDescription);
            } catch(Exception e)
            {

            }
            return RedirectToAction("Index");
        }
    }
}
