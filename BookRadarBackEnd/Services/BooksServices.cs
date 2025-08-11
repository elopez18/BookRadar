using BookRadarBackEnd.Dto;
using BookRadarBackEnd.Models;
using BookRadarBackEnd.Repositories;

namespace BookRadarBackEnd.Services
{
    public class BooksServices : IBooksServices
    {
        private readonly IBooksRepositories _booksRepositories;
        private readonly ILogger<BooksServices> _logger;
        public BooksServices(IBooksRepositories BooksRepositories, ILogger<BooksServices> logger)
        {
            _booksRepositories = BooksRepositories;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene una lista de libros por autor desde la base de datos o una API externa.
        /// </summary>
        /// <param name="AuthorName"></param>
        /// <returns></returns>
        public async Task<List<BooksModel>> GetBooksByAuthorServices(string AuthorName)
        {
            List<BooksModel> listBusqueda = new List<BooksModel>();

            try
            {
                listBusqueda = await _booksRepositories.GetBooksByAuthorRepositories(AuthorName);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en la consulta de libros por autor. Detalle del error: " + ex.Message);
            }

            return listBusqueda;
        }
        /// <summary>
        /// Crea un libro en la base de datos mediante SP y lo registra en el historial de búsqueda de libros.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> CreateBookServices(BooksDTO data)
        {
            var responseRepositories = await _booksRepositories.CreateBookRepositories(data);
            return responseRepositories;
        }

        /// <summary>
        /// Obtiene el historial de búsquedas de libros desde la base de datos mediante SP.
        /// </summary>
        /// <returns></returns>
        public async Task<List<HistorialBusquedasModel>> GetBooksHistoryServices()
        {
            List<HistorialBusquedasModel> listHistorico = new List<HistorialBusquedasModel>();
            
            try
            {
                listHistorico = await _booksRepositories.GetBooksHistoryRepositories();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error en la consulta del historial de libros. Detalle del error: " + ex.Message);
            }

            return listHistorico;
        }
       
    }
}
