using Bill.IRepository;
using NHibernate;

namespace Bill.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionProvider _sessionProvider;
        private ITransaction _transaction;

        public UnitOfWork(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
            Session = _sessionProvider.GetCurrentSession();
        }

        public ISession Session { get; }

        public void Dispose()
        {
            _sessionProvider.DisposeCurrentSession();
        }

        public void Start()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.IsActive) _transaction.Rollback();
        }
    }
}