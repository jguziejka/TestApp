using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Models;
using TestApp.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp.Controllers
{
    public class MainController : Controller
    {
        private ISearchService _searchService;

        public MainController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Results(SearchResultsModel model)
        {
            return PartialView(model);
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel search)
        {
            if (string.IsNullOrWhiteSpace(search.City) && string.IsNullOrWhiteSpace(search.State) && string.IsNullOrWhiteSpace(search.Zip))
            {
                ViewData.ModelState.AddModelError(string.Empty, "Combination of City and State, and/or Zip code are required.");
            }
            else if (string.IsNullOrWhiteSpace(search.Zip) && (string.IsNullOrWhiteSpace(search.City) || string.IsNullOrWhiteSpace(search.State)))
            {
                ViewData.ModelState.AddModelError(string.Empty, "Combination of City and State are required if not using zip code.");
            }
            else if ((!string.IsNullOrWhiteSpace(search.City) && string.IsNullOrWhiteSpace(search.State)))
            {
                ViewData.ModelState.AddModelError("State", "State is required if using City.");
            }
            else if ((string.IsNullOrWhiteSpace(search.City) && !string.IsNullOrWhiteSpace(search.State)))
            {
                ViewData.ModelState.AddModelError("City", "City is required if using State.");
            }

            if (ModelState.IsValid)
            {
                var results = await _searchService.RunSearch(new SearchModel(search));
                search.Results = results;
                return View(search);                
            }

            return View();
        }
    }
}
