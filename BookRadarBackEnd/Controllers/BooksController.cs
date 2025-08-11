using AutoWrapper.Wrappers;
using BookRadarBackEnd.Dto;
using BookRadarBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookRadarBackEnd.Controllers
{
    /// <summary>
    /// Controlador para la gestión de libros.
    /// </summary>
    [ApiController]
    [Route("/api/Books")]
    //[Authorize]
    public class BooksController : Controller
    {
        /// <summary>
        /// Servicio para la gestión de libros.
        /// </summary>
        private readonly IBooksServices _booksServices;
        private readonly ILogger<BooksController> _logger;

        /// <summary>
        /// Constructor del controlador BooksController.
        /// </summary>
        /// <param name="booksServices"></param>
        /// <param name="logger"></param>
        public BooksController(IBooksServices booksServices, ILogger<BooksController> logger)
        {
            _booksServices = booksServices;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene una lista de libros por autor.
        /// </summary>
        /// <param name="AuthorName"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("GetBooksByAuthor")]
        public async Task<IActionResult> GetBooksByAuthor(string AuthorName)
        {
            try
            {
                _logger.LogInformation("Consulta de libros por el autor " + AuthorName + " registrada en el sistema.");

                var listaLibrosPorAutor = await _booksServices.GetBooksByAuthorServices(AuthorName);

                if (listaLibrosPorAutor.Count() > 0)
                {
                    return Ok(new ApiResponse("Consulta Exitosa de libros por autor.", listaLibrosPorAutor, 200));
                }
                else
                {
                    return NotFound(new ApiResponse("No existen libros registrados en el sistema para el autor seleccionado.", null, 404));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en consulta de libros por autor. Detalle del error: ", ex.Message);
                return NotFound(new ApiResponse("No encontrado.", null, 550));
            }
        }

        /// <summary>
        /// Crea un nuevo libro en el sistema.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] BooksDTO model)
        {

            try
            {
                _logger.LogInformation("Creación de libro por el autor " + model + " registrada en el sistema.");
                var book = await _booksServices.CreateBookServices(model);
                
                if (book)
                {
                    return Ok(new ApiResponse("Libro creado exitosamente.", book, 200));
                }
                else
                {
                    return NotFound(new ApiResponse("no es posible insertar el registro.", book, 404));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear libro. Detalle del error: ", ex.Message);
                return NotFound(new ApiResponse("CreateActo Not Found.", null, 550));
            }
        }

        /// <summary>
        /// Obtiene el historial de libros registrados en el sistema.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("GetBooksHistory")]
        public async Task<IActionResult> GetBooksHistory()
        {
            try
            {
                _logger.LogInformation("Consulta del historial de libros registrada en el sistema.");

                var listaLibrosPorAutor = await _booksServices.GetBooksHistoryServices();

                if (listaLibrosPorAutor.Count() > 0)
                {
                    return Ok(new ApiResponse("Consulta exitosa del historial de libros.", listaLibrosPorAutor, 200));
                }
                else
                {
                    return NotFound(new ApiResponse("No existe historial de libros en el sistema.", null, 404));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en consulta de historial de libros. Detalle del error: ", ex.Message);
                return NotFound(new ApiResponse("No encontrado.", null, 550));
            }
        }
    }
}
