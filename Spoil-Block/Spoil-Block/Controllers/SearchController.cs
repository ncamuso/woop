using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Spoil_Block.DAL.Abstract;

namespace Spoil_Block.Controllers
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
    }
}
