using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bill.Domain;

namespace Bill.DataAccess
{
    public interface IRepository<T> where T : EntityInt32
    {
        IList<T> GetAll();
        IList<T> GetBy(Expression<Func<T, bool>> condition);
        int Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void BatchAdd(IEnumerable<T> entities);
        void BatchUpdate(IEnumerable<T> entities);
        void BatchDelete(IEnumerable<T> entities);
        void SaveOrUpdate(T entities);
        void Flush();
    }
}