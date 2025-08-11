using BookRadarFrontEnd.Models.books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.Services.Books
{
    public interface IBookSearchByAuthorService
    {
        Task<ResponseSearch> GetBooksByAuthorAsync(string author);
        Task<bool> SaveBookSearchAsync(saveBookModel libroSeleccionado);
    }
}
