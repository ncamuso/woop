using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.DAL.Concrete;
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
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            if (model.query == null) return View();

            try
            {
                var searchResults = await _searchService.GetSearchResultsAsync(model.query);
                model.resultsList = searchResults.Item1;
                model.errorMessage = searchResults.Item2;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                model.errorMessage = "We're having difficulty processing the results from IMDb.  Please try again later.";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                model.errorMessage = "We're having difficulty processing the results from IMDb.  Please try again later.";
            }
            catch(InvalidJSONException e)
            {
                Console.WriteLine(e.Message);
                model.errorMessage = "We're having difficulty processing the results from IMDb.  Please try again later.";
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                model.errorMessage = "We're having difficulty connecting to the IMDb server. Please check your internet connection or try again later.";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                model.errorMessage = "Sorry, something went wrong.  Please try again later.";
            }

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
