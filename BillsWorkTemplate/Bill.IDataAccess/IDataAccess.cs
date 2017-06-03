using System.Collections.Generic;
using Bill.Domain;

namespace Bill.IDataAccess
{
    public interface IDataAccess<T> where T : EntityInt32
    {
        IList<T> GetAll();
        T GetBy(int id);
        int Add(T entity);
        void Update(T entity);
        void SaveOrUpdate(T entity);
        void Remove(T entity);
        void Flush();
    }
}