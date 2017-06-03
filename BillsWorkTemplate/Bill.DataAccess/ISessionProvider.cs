using NHibernate;

namespace Bill.DataAccess
{
    public interface ISessionProvider
    {
        ISession GetCurrentSession();
        IStatelessSession GetCurrentStatelessSession();
        void DisposeCurrentSession();
        void DisposeCurrentStatelessSession();
    }
}