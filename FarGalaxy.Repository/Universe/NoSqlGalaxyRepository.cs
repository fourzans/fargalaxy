using FarGalaxy.Contracts.DataAccess;
using FarGalaxy.Contracts.Weather;
using FarGalaxy.Entities;
using FarGalaxy.Repositories;
using FarGalaxy.Repository.Constants;

namespace FarGalaxy.Repository
{
    public class NoSqlGalaxyRepository : IGalaxyRepository
    {
        private const string GalaxyKeyName = NoSql.Keys.Galaxy;

        private readonly INoSqlProvider _storageProvider;

        public NoSqlGalaxyRepository(INoSqlProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public Galaxy GetDefaultGalaxy()
        {
            return _storageProvider.Get<Galaxy>(GalaxyKeyName);
        }

        public SolarSystem GetSolarSystem()
        {
            return GetDefaultGalaxy().SolarSystem;
        }
    }
}
