using System.Collections.Generic;
using System.Linq;
using Bill.Domain.Domain1;
using Bill.IApplication;
using Bill.IRepository;

namespace Bill.Application
{
    public class Domain1Service : IDomain1Service
    {
        private readonly IDomain1Repository _domain1DataService;

        public Domain1Service(IDomain1Repository domain1DataService)
        {
            _domain1DataService = domain1DataService;
        }

        public List<DomainOne> GetSomeDomain1S(int someId)
        {
            return _domain1DataService.GetDomain1SBySomeConditions("some condition", someId).ToList();
        }
    }
}