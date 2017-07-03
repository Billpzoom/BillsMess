using System.Collections.Generic;
using Bill.Domain;

namespace Bill.IRepository
{
    public interface IRepository<T> where T : EntityUuidString
    {
        IList<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void SaveOrUpdate(T entities);
        void Flush();
    }
}