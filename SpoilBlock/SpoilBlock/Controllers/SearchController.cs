using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models.ViewModels;

namespace SpoilBlock.Controllers
{
    public class SearchController : Controller
    {
        private IIMDbSearchService _searchService;
        public SearchController(IIMDbSearchService searchService)
        {
            _searchService = searchService;
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
    }
}
