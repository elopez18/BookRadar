namespace BookRadarBackEnd.Helpers
{
    public class GetConfig: IGetConfig
    {
        public IConfigurationRoot GetConfiguration()
        {
            var secret = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

            return secret.Build();
        }
    }
}
