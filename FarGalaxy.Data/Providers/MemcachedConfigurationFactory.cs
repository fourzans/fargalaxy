using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using FarGalaxy.Data.Constants;
using static System.Convert;
using static Enyim.Caching.Memcached.MemcachedProtocol;

namespace FarGalaxy.Data.Providers
{
    public class MemcachedConfigurationFactory
    {
        /// <summary>
        ///     The server
        /// </summary>
        private static readonly string Server;

        /// <summary>
        ///     The port
        /// </summary>
        private static readonly int Port;

        /// <summary>
        ///     The username
        /// </summary>
        private static readonly string Username;

        /// <summary>
        ///     The password
        /// </summary>
        private static readonly string Password;

        /// <summary>
        ///     Initializes the <see cref="MemcachedConfigurationFactory" /> class.
        /// </summary>
        static MemcachedConfigurationFactory()
        {
            var memcachedConnectionString = Cache.MemcachedConnectionString;
            string[] configuration = memcachedConnectionString.Split(',');
            Server = configuration[0].Split(':')[0];
            Port = ToInt32(configuration[0].Split(':')[1]);
            Username = configuration[1].Split('=')[1];
            Password = configuration[2].Split('=')[1];
        }

        /// <summary>
        ///     Builds this instance.
        /// </summary>
        /// <returns></returns>
        public static MemcachedClientConfiguration Build()
        {
            MemcachedClientConfiguration configuration = new MemcachedClientConfiguration
            {
                Authentication =
                {
                    Type = typeof(PlainTextAuthenticator),
                    Parameters =
                    {
                        ["userName"] = Username,
                        ["password"] = Password,
                        ["zone"] = string.Empty
                    }
                },
                Protocol = Binary
            };
            configuration.AddServer(Server, Port);
            return configuration;
        }
    }
}
