using System;
using NHibernate;

namespace Bill.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _transaction = session.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction?.Rollback();
        }

        public void SaveChanges()
        {
            if (_transaction == null)
                throw new InvalidOperationException("UnitOfWork have already been saved.");

            _transaction.Commit();
            _transaction = null;
        }
    }
}