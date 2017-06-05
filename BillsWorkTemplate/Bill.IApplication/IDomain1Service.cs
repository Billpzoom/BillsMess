using System.Collections.Generic;
using Bill.Domain.Domain1;

namespace Bill.IApplication
{
    public interface IDomain1Service
    {
        List<DomainOne> GetSomeDomain1S(int someId);
    }
}