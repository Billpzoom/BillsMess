using System.Collections.Generic;
using Bill.Domain;

namespace Bill.IRepository
{
    public interface IRepository<T> where T : EntityInt32
    {
        IList<T> GetAll();
        void Update(T entity);
        void Remove(T entity);
        void BatchAdd(IEnumerable<T> entities);
        void BatchUpdate(IEnumerable<T> entities);
        void BatchDelete(IEnumerable<T> entities);
        void SaveOrUpdate(T entities);
        void Flush();
    }
}