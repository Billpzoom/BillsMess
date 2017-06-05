using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bill.Domain;
using NHibernate;

namespace Bill.Repository
{
    public class Repository<T> where T : EntityInt32
    {
        protected readonly ISession Session;
        protected readonly IStatelessSession StatelessSession;

        public Repository(ISession session)
        {
            Session = session;
        }

        public Repository(IStatelessSession session)
        {
            StatelessSession = session;
        }

        #region IRepository<T> 成员

        /// <summary>
        ///     获得所有数据
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll()
        {
            return Session.QueryOver<T>().List<T>();
        }

        /// <summary>
        ///     根据条件查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public IList<T> GetBy(Expression<Func<T, bool>> condition)
        {
            return Session.QueryOver<T>().Where(condition).List();
        }

        /// <summary>
        ///     更新数据
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            Session.Update(entity);
        }

        /// <summary>
        ///     删除数据
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            if (entity == null)
                return;
            Session.Delete(entity);
        }

        /// <summary>
        ///     批量添加数据
        /// </summary>
        /// <param name="entities"></param>
        public void BatchAdd(IEnumerable<T> entities)
        {
            foreach (var t in entities)
                StatelessSession.Insert(t);
        }

        /// <summary>
        ///     批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        public void BatchUpdate(IEnumerable<T> entities)
        {
            foreach (var t in entities)
                StatelessSession.Update(t);
        }

        /// <summary>
        ///     批量删除数据
        /// </summary>
        /// <param name="entities"></param>
        public void BatchDelete(IEnumerable<T> entities)
        {
            foreach (var t in entities)
                StatelessSession.Delete(t);
        }

        /// <summary>
        ///     根据实体状态自动判断删除还是更新
        /// </summary>
        /// <param name="entity"></param>
        public void SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        /// <summary>
        ///     提交数据到数据库
        /// </summary>
        public void Flush()
        {
            Session?.Flush();
        }

        #endregion
    }
}