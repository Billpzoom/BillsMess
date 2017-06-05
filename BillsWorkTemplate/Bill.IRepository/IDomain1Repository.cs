using System.Collections.Generic;
using Bill.Domain.Domain1;

namespace Bill.IRepository
{
    public interface IDomain1Repository : IRepository<DomainOne>
    {
        IList<DomainOne> GetDomain1SBySomeConditions(string condition1, int contition2);
    }
}