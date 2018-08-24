using System;

namespace FarGalaxy.Contracts.DataAccess
{
    public interface IDataAccessProvider
    {
        T Get<T>(string key);
        
        void Add<T>(string key, T value);
        
        void Add(string key, string value);
        
        void Add<T>(string key, T value, TimeSpan timeToLive);
    }
}
