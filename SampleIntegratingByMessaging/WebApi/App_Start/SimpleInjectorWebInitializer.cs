using IoC;
using Microsoft.Owin;
using SharedKernel.Commands;
using SharedKernel.Events;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.WebApi;
using System.Web;
using System.Web.Http;
using WebApi.Helpers;

namespace WebApi.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {

        public static void Initialize(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Chamada dos módulos do Simple Injector
            BootsTrapper.Register(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.RegisterPerWebRequest(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying())
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;


            });

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            DomainEvent.Container = new DomainEventsContainer(config.DependencyResolver);
            DomainCommand.Container = new DomainEventsContainer(config.DependencyResolver);

        }
    }
}