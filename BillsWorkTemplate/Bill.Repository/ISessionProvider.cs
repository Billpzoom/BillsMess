using NHibernate;

namespace Bill.Repository
{
    public interface ISessionProvider
    {
        ISession GetCurrentSession();
        IStatelessSession GetCurrentStatelessSession();
        void DisposeCurrentSession();
        void DisposeCurrentStatelessSession();
    }
}