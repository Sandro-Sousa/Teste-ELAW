using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Teste_Elaw_WebCrawler.Core.Entities;
using Teste_Elaw_WebCrawler.Data.Mappings;

namespace Teste_Elaw_WebCrawler.AppStart
{
    public static class NHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c
                        .Server("PC-DEVELOPER")
                        .Database("WebCrawlerDB")
                        .Username("sa")
                        .Password("12345")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ExecutionLogMap>())
                .BuildSessionFactory();
        }
    }
}