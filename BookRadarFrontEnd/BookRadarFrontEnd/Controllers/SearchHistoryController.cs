using BookRadarFrontEnd.BLL.History;
using BookRadarFrontEnd.Models.History;
using Microsoft.AspNetCore.Mvc;

namespace BookRadarFrontEnd.Controllers
{
    public class SearchHistoryController : Controller
    {
        readonly ISearchHistoryBLL _searchHistoryBLL;

        public SearchHistoryController(ISearchHistoryBLL searchHistoryBLL)
        {
            _searchHistoryBLL = searchHistoryBLL;
        }


        public async Task<IActionResult> Index()
        {
            var searchHistory = await _searchHistoryBLL.GetBooksHistoryAsync();
            if (searchHistory == null)
            {
                searchHistory = new ResponseHistory();
                ViewBag.ErrorMessage = "No se encontraron registros de búsqueda.";
            }
            return View(searchHistory);
        }
    }
}
