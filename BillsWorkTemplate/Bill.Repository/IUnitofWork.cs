using System;

namespace Bill.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}