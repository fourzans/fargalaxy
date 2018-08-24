using static System.Configuration.ConfigurationManager;

namespace FarGalaxy.Data.Constants
{
    public static class Cache
    {
        /// <summary>
        ///     The memcached connection string
        /// </summary>
        public static readonly string MemcachedConnectionString = AppSettings["MemcachedConnectionString"];
    }
}
