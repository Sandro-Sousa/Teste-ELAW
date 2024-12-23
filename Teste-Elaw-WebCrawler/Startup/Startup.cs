using Microsoft.Extensions.DependencyInjection;
using Teste_Elaw_WebCrawler.AppStart;
using Teste_Elaw_WebCrawler.Data.Repositories;
using Teste_Elaw_WebCrawler.Infrastructure.Services;

namespace Teste_Elaw_WebCrawler.Startup
{
    public class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            var sessionFactory = NHibernateConfig.CreateSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());

            services.AddTransient<ExecutionLogRepository>();

            services.AddSingleton("https://proxyservers.pro/proxy/list/order/updated/order_dir/desc");

            services.AddTransient<WebCrawlerService>();

            return services.BuildServiceProvider();
        }
    }
}
