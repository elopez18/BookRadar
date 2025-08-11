using BookRadarFrontEnd.Utils.Config;

namespace BookRadarFrontEnd.Extentions
{
    public static class GetConfigExtentions
    {

        public static IServiceCollection AddGetConfigExtentions(this IServiceCollection services)
        {
            services.AddScoped<IGetConfig, GetConfig>();

            return services;
        }
    }
}
