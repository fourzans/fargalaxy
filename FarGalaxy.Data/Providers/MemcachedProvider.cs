using System;
using FarGalaxy.Contracts.DataAccess;
using ServiceStack.Caching;

namespace FarGalaxy.Data.Providers
{
    public class MemcachedProvider : ICacheProvider
    {
        private readonly ICacheClient _client;

        public MemcachedProvider(ICacheClient client)
        {
            _client = client;
        }

        public T Get<T>(string key)
        {
            return _client.Get<T>(key);
        }

        public void Add<T>(string key, T value)
        {
            _client.Set(key, value);
        }

        public void Add(string key, string value)
        {
            _client.Set(key, value);
        }

        public void Add<T>(string key, T value, TimeSpan timeToLive)
        {
            _client.Set(key, value, timeToLive);
        }
    }
}
