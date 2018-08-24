using System.Net.Http.Formatting;
using System.Web.Http;
using WebApi.OutputCache.Core.Cache;
using WebApi.OutputCache.V2;

namespace FarGalaxy.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });
            config.CacheOutputConfiguration().RegisterCacheOutputProvider(() => new MemoryCacheDefault());
        }
    }
}
