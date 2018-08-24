using static System.Configuration.ConfigurationManager;


namespace FarGalaxy.Repository.Constants
{
    public static class NoSql
    {
        public static readonly string RedisConnectionString = AppSettings["RedisConnectionString"];

        public static class Keys
        {
            public const string Forecast = nameof(Forecast);

            public const string Galaxy = nameof(Galaxy);

            public static readonly string Volatile = "day:{0}";
        }
    }
}
