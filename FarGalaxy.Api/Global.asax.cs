using FarGalaxy.Api.App_Start;
using System.Web.Http;

namespace FarGalaxy.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            AutofacConfig.ConfigureContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            JobScheduler.Start();
        }
    }
}
