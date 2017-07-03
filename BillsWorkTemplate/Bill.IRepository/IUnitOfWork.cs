using System;

namespace Bill.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Start();
        void Commit();
        void Rollback();
    }
}