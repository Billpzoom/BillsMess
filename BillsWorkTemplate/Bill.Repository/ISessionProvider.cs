using System;
using NHibernate;

namespace Bill.Repository
{
    public interface ISessionProvider : IDisposable
    {
        ISession GetCurrentSession();
        IStatelessSession GetCurrentStatelessSession();
        void DisposeCurrentSession();
        void DisposeCurrentStatelessSession();
    }
}