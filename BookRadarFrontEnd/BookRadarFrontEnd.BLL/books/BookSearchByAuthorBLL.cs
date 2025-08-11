using BookRadarFrontEnd.Models.books;
using BookRadarFrontEnd.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.BLL.books
{
    public class BookSearchByAuthorBLL: IBookSearchByAuthorBLL
    {
        private readonly IBookSearchByAuthorService _bookSearchByAuthorService;
        public BookSearchByAuthorBLL(IBookSearchByAuthorService bookSearchByAuthorService)
        {
            _bookSearchByAuthorService = bookSearchByAuthorService;
        }
        public async Task<ResponseSearch> GetBooksByAuthorAsync(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                return new ResponseSearch();
            return await _bookSearchByAuthorService.GetBooksByAuthorAsync(author);
        }

        public async Task<bool> SaveBookSearchAsync(Book libroSeleccionado)
        {
            if (string.IsNullOrWhiteSpace(libroSeleccionado.titulo))
                return false;

            saveBookModel SaveBook = new saveBookModel
            {
                Titulo = libroSeleccionado.titulo,
                AnioPublicacion = libroSeleccionado.anioPublicacion,
                Editorial = libroSeleccionado.editorial,
                AutorBuscado = libroSeleccionado.autorBuscado == null ? "autor no disponible": libroSeleccionado.autorBuscado,
                FechaConsulta = libroSeleccionado.fechaConsulta
            };

            return await _bookSearchByAuthorService.SaveBookSearchAsync(SaveBook);
        }
    }
}
