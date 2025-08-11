using BookRadarFrontEnd.BLL.books;
using BookRadarFrontEnd.Services.Books;

namespace BookRadarFrontEnd.Extentions
{
    public static class BookSearchByAuthorExtentions
    {

         public static IServiceCollection AddBookSearchByAuthorExtentions(this IServiceCollection services)
         {
             services.AddScoped<IBookSearchByAuthorBLL, BookSearchByAuthorBLL>();
             services.AddHttpClient<IBookSearchByAuthorService, BookSearchByAuthorService>();


            return services;
         }
    }
}

