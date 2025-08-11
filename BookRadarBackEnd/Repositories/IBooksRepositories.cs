using BookRadarBackEnd.Dto;
using BookRadarBackEnd.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BookRadarBackEnd.Repositories
{
    public interface IBooksRepositories
    {
        /// <summary>
        /// Obtiene una lista de libros por autor desde la base de datos o una API externa.
        /// </summary>
        /// <param name="AuthorName"></param>
        /// <returns></returns>
        Task<List<BooksModel>> GetBooksByAuthorRepositories(string AuthorName);

        /// <summary>
        /// Obtiene una lista de libros por autor desde una API externa.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> CreateBookRepositories(BooksDTO data);

        /// <summary>
        /// Obtiene una lista de libros del historial de búsqueda desde la base de datos.
        /// </summary>
        /// <returns></returns>
        Task<List<HistorialBusquedasModel>> GetBooksHistoryRepositories();

    }
}
