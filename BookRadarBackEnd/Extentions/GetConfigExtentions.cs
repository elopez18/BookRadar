using BookRadarBackEnd.Helpers;

namespace BookRadarBackEnd.Extentions
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
