using System.Collections.Generic;
using System.Linq;
using Bill.Domain.Domain1;
using Bill.IApplication;
using Bill.IDataAccess;

namespace Bill.Application
{
    public class Domain1Service : IDomain1Service
    {
        private readonly IDomain1DataAccess _domain1DataService;

        public Domain1Service(IDomain1DataAccess domain1DataService)
        {
            _domain1DataService = domain1DataService;
        }

        public List<Domain1> GetSomeDomain1S(int someId)
        {
            return _domain1DataService.GetAll().ToList();
        }
    }
}