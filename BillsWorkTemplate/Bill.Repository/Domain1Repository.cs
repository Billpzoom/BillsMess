using System;
using System.Collections.Generic;
using Bill.Domain.Domain1;
using Bill.IRepository;

namespace Bill.Repository
{
    public class Domain1Repository : Repository<DomainOne>, IDomain1Repository
    {
        public Domain1Repository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public IList<DomainOne> GetDomain1SBySomeConditions(string condition1, int contition2)
        {
            var session = SessionProvider.GetCurrentSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var results = session.QueryOver<DomainOne>().Where(d => d.PropertyOne == condition1).List();
                    tx.Commit();
                    return results;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}