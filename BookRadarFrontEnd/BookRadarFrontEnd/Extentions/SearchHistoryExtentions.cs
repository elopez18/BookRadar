
using BookRadarFrontEnd.BLL.History;
using BookRadarFrontEnd.Services.History;

namespace BookRadarFrontEnd.Extentions
{
    public static class SearchHistoryExtentions
    {

        public static IServiceCollection AddSearchHistoryExtentions(this IServiceCollection services)
        {
            services.AddScoped<ISearchHistoryBLL, SearchHistoryBLL>();
            services.AddHttpClient<ISearchHistoryService, SearchHistoryService>();


            return services;
        }


    }
}
