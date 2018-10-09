using Autofac;
using System.Reflection;
using System.Web.Http;
using Autofac.Integration.WebApi;
using WeatherService;
using WeatherService.Interfaces;

namespace Weather
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<WeatherService.WeatherService>().As<IWeatherService>();
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
