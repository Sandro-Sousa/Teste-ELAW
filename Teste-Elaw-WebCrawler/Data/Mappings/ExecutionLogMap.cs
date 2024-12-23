using FluentNHibernate.Mapping;
using Teste_Elaw_WebCrawler.Core.Entities;

namespace Teste_Elaw_WebCrawler.Data.Mappings
{
    public class ExecutionLogMap : ClassMap<ExecutionLog>
    {
        public ExecutionLogMap()
        {
            Table("ExecutionLog");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.StartDate).Not.Nullable();
            Map(x => x.EndDate).Not.Nullable();
            Map(x => x.PageCount).Not.Nullable();
            Map(x => x.LineCount).Not.Nullable();
            Map(x => x.JsonFilePath).Not.Nullable();
            Map(x => x.CreatedAt).Not.Nullable().Default("GETDATE()");
        }
    }
}
