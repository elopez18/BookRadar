using BookRadarFrontEnd.BLL.books;
using BookRadarFrontEnd.Helpers;
using BookRadarFrontEnd.Models.books;
using BookRadarFrontEnd.SessionMiddleware;
using Microsoft.AspNetCore.Mvc;

namespace BookRadarFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookSearchByAuthorBLL _bookSearchByAuthorBLL;
        private readonly IHelper _helper;
        private readonly ISessionService _sessionService;
        public HomeController(ILogger<HomeController> logger, IBookSearchByAuthorBLL bookSearchByAuthorBLL, IHelper helper, ISessionService sessionService)
        {
            _logger = logger;
            _bookSearchByAuthorBLL = bookSearchByAuthorBLL;
            _helper = helper;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            var libroModel = new ResponseSearch();

            return View(libroModel);
        }


        public async Task<IActionResult> abrirBuscarModal()
        {
            return PartialView("_BuscarModal");
        }

        [HttpPost]
        public async Task<IActionResult> buscarPorAutor(string Autor)
        {

            string Msg = string.Empty;
            bool result = false;

            if (string.IsNullOrEmpty(Autor))
            {
                ModelState.AddModelError("Autor", "El campo Autor es obligatorio.");
                return PartialView("_BuscarModal");
            }
            var libros = await _bookSearchByAuthorBLL.GetBooksByAuthorAsync(Autor);

            result = libros.statusCode == 200 ? true : false;
            if (result)
            {
                _sessionService.SetObject("LibrosModel", libros);
            }

            var Result = new
            {
                msg = Msg,
                resultado = result,
                vista = _helper.RenderPartial(this, "~/Views/Home/Index.cshtml", libros)
            };
            return Json(Result);

        }

        [HttpPost]
        public async Task<IActionResult> GuardarBusqueda(string titulo)
        {

            string Msg = string.Empty;
            bool result = false;

            if (string.IsNullOrEmpty(titulo))
            {
                Msg = "Se presento un problema al guardar el titulo por favor intentelo de nuevo";
            }
            else
            {
                var libroslist = _sessionService.GetObject<ResponseSearch>("LibrosModel");
                if (libroslist == null)
                {
                    Msg = "Se presentó un problema al guardar el título, por favor inténtelo de nuevo";
                }
                else
                {
                    Book Guardartitulo = libroslist.BookList.FirstOrDefault(x=>x.titulo == titulo);

                    result = await _bookSearchByAuthorBLL.SaveBookSearchAsync(Guardartitulo);
                    if (result)
                    {
                        Msg = "Se guardo el titulo correctamente en base de datos, podra verlo de nuevo en la opcion de historial de busquedas";
                    }
                    else
                    {
                        Msg = "Se presentó un problema al guardar el título, por favor inténtelo de nuevo";
                    }
                }
            }

                var Result = new
                {
                    msg = Msg,
                    resultado = result
                };
            return Json(Result);
        }

    }
}
