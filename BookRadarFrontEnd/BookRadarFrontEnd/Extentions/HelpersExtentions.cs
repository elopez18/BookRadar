using BookRadarFrontEnd.Helpers;

namespace BookRadarFrontEnd.Extentions
{
    public static class HelpersExtentions
    {
        public static IServiceCollection AddHelpersExtentions(this IServiceCollection services)
        {
            services.AddScoped<IHelper, Helper>();

            return services;
        }
    }
}
