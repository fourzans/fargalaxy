using System;
using FarGalaxy.Contracts.DataAccess;
using StackExchange.Redis.Extensions.Core;

namespace FarGalaxy.Data
{
    public class RedisProvider : INoSqlProvider
    {
        private readonly ICacheClient _client;
        
        public RedisProvider(ICacheClient client)
        {
            _client = client;
        }

        public void Add<T>(string key, T value)
        {
            _client.Add(key, value);
        }

        public void Add(string key, string value)
        {
            _client.Add(key, value);
        }

        public void Add<T>(string key, T value, TimeSpan timeToLive)
        {
            _client.Add(key, value, timeToLive);
        }

        public T Get<T>(string key)
        {
            return _client.Get<T>(key);
        }
    }
}
