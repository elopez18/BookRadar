using BookRadarFrontEnd.Models.books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.BLL.books
{
    public interface IBookSearchByAuthorBLL
    {
        Task<ResponseSearch> GetBooksByAuthorAsync(string author);
        Task<bool> SaveBookSearchAsync(Book libroSeleccionado);
    }
}
