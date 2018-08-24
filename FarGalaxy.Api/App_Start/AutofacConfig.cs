using Autofac;
using Autofac.Integration.WebApi;
using FarGalaxy.IoC;
using static System.Reflection.Assembly;
using static System.Web.Http.GlobalConfiguration;

namespace FarGalaxy.Api.App_Start
{
    public static class AutofacConfig
    {
        private static IContainer Container { get; set; }

        public static void ConfigureContainer()
        {
            WebApiBuilder builder = new WebApiBuilder();

            builder.RegisterApiControllers(GetExecutingAssembly());

            Container = builder.Build();

            Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}