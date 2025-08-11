using BookRadarBackEnd.Dto;
using BookRadarBackEnd.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BookRadarBackEnd.Services
{
    public interface IBooksServices
    {
        /// <summary>
        /// Obtiene una lista de libros por autor desde la base de datos o una API externa.
        /// </summary>
        /// <param name="AuthorName"></param>
        /// <returns></returns>
        Task<List<BooksModel>> GetBooksByAuthorServices(string AuthorName);

        /// <summary>
        /// Crea un libro en la base de datos mediante SP y lo registra en el historial de búsqueda de libros.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> CreateBookServices(BooksDTO data);

        /// <summary>
        /// Obtiene el historial de búsquedas de libros desde la base de datos mediante SP.
        /// </summary>
        /// <returns></returns>
        Task<List<HistorialBusquedasModel>> GetBooksHistoryServices();
    }
}
