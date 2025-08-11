namespace BookRadarFrontEnd.SessionMiddleware
{
    public interface ISessionService
    {
        T GetObject<T>(string key);
        void SetObject<T>(string key, T value);
    }
}
