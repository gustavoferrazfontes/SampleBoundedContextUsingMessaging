using Microsoft.Owin;
using Owin;
using SimpleInjector.Integration.Web;
using System.Web.Http;
using WebApi;

[assembly: OwinStartup(typeof(Startup))]
namespace WebApi
{
    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            SimpleInjectorWebInitializer.Initialize();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

        }
    }
}