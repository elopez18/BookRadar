using BookRadarBackEnd.Repositories;
using BookRadarBackEnd.Services;

namespace BookRadarBackEnd.Extentions
{
    public static class BooksExtentions
    {
        public static IServiceCollection AddBooksExtentions(this IServiceCollection services)
        {
            services.AddScoped<IBooksServices, BooksServices>();
            services.AddScoped<IBooksRepositories, BooksRepositories>();

            return services;
        }
    }
}
