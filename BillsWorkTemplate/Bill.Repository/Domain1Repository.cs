using Bill.Domain.Domain1;
using Bill.IDataAccess;

namespace Bill.Repository
{
    public class Domain1Repository : Repository<Domain1>, IDomain1DataAccess
    {
        public Domain1Repository(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }
    }
}