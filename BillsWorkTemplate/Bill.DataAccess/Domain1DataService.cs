using System.Collections.Generic;
using System.Linq;
using Bill.Domain.Domain1;
using Bill.IDataAccess;

namespace Bill.DataAccess
{
    public class Domain1DataService : IDomain1DataAccess
    {
        private readonly IRepository<Domain1> _domain1Repository;

        public Domain1DataService(IRepository<Domain1> domain1Repository)
        {
            _domain1Repository = domain1Repository;
        }

        public IList<Domain1> GetAll()
        {
            return _domain1Repository.GetAll();
        }

        public Domain1 GetBy(int id)
        {
            return _domain1Repository.GetBy(d => d.Id == id).FirstOrDefault();
        }

        public int Add(Domain1 entity)
        {
            return _domain1Repository.Add(entity);
        }

        public void Update(Domain1 entity)
        {
            _domain1Repository.Update(entity);
        }

        public void SaveOrUpdate(Domain1 entity)
        {
            _domain1Repository.SaveOrUpdate(entity);
        }

        public void Remove(Domain1 entity)
        {
            _domain1Repository.Remove(entity);
        }

        public void Flush()
        {
            _domain1Repository.Flush();
        }
    }
}