
namespace Teste_Elaw_WebCrawler.Core.Entities
{
    public class ExecutionLog
    {
        public virtual int Id { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int PageCount { get; set; }
        public virtual int LineCount { get; set; }
        public virtual string JsonFilePath { get; set; }
        public virtual DateTime CreatedAt { get; set; }
    }
}
