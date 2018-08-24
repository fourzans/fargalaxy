using Autofac;
using FarGalaxy.Contracts.DataAccess;
using FarGalaxy.Data;
using FarGalaxy.Data.Providers;
using FarGalaxy.Repositories;
using FarGalaxy.Repository;
using FarGalaxy.Repository.Constants;
using FarGalaxy.Services;
using FarGalaxy.Services.WeatherConditions.Weather;
using Newtonsoft.Json;
using ServiceStack.Caching.Memcached;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Newtonsoft;
using static Newtonsoft.Json.NullValueHandling;
using static Newtonsoft.Json.TypeNameHandling;

namespace FarGalaxy.IoC
{
    public class BuilderBase : ContainerBuilder
    {
        protected BuilderBase()
        {
            this.Register(serializer => new NewtonsoftSerializer(new JsonSerializerSettings
            {
                TypeNameHandling = Auto,
                NullValueHandling = Include
            })).As<ISerializer>().SingleInstance();

            this.Register(cacheClient => new StackExchangeRedisCacheClient(Container.Resolve<ISerializer>(),
                 NoSql.RedisConnectionString))
             .As<ICacheClient>().SingleInstance();

            this.Register<ServiceStack.Caching.ICacheClient>(
                    cacheClient => new MemcachedClientCache(MemcachedConfigurationFactory.Build()))
                .As<ServiceStack.Caching.ICacheClient>().SingleInstance();

            this.Register(redisProvider => new RedisProvider(Container.Resolve<ICacheClient>()))
               .As<INoSqlProvider>().SingleInstance();

            this.Register(
                    redisProvider => new MemcachedProvider(Container.Resolve<ServiceStack.Caching.ICacheClient>()))
                .As<ICacheProvider>().SingleInstance();

            this.Register(galaxyRepository => new NoSqlGalaxyRepository(Container.Resolve<INoSqlProvider>()))
                .As<IGalaxyRepository>().SingleInstance();

            this.Register(weatherRepository => new NoSqlWeatherRepository(Container.Resolve<INoSqlProvider>()))
                .As<IWeatherRepository>().SingleInstance();

            this.Register(
                    weatherConditionsService => new WeatherConditionsService(Container.Resolve<IGalaxyRepository>()))
                .As<IWeatherConditionsService>().SingleInstance();

        }

        private static IContainer Container { get; set; }

        public IContainer Build()
        {
            Container = base.Build();
            return Container;
        }
    }
}
