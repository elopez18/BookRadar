

using BookRadarFrontEnd.SessionMiddleware;

namespace BookRadarFrontEnd.Extentions
{
    public static class SessionServiceExtentions
    {
        public static IServiceCollection AddSessionServiceExtentions(this IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();

            return services;
        }
    }
}
