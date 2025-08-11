using Newtonsoft.Json;

namespace BookRadarFrontEnd.SessionMiddleware
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T GetObject<T>(string key)
        {
            var value = _httpContextAccessor.HttpContext.Session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        public void SetObject<T>(string key, T value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
