using NHibernate;
using Teste_Elaw_WebCrawler.Core.Entities;

namespace Teste_Elaw_WebCrawler.Data.Repositories
{
    public class ExecutionLogRepository
    {
        private readonly ISession _session;

        public ExecutionLogRepository(ISession session)
        {
            _session = session;
        }

        public void Save(ExecutionLog log)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(log);
                transaction.Commit();
            }
        }
    }
}
