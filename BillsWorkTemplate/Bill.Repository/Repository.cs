using System.Collections.Generic;
using Bill.Domain;
using Bill.IRepository;
using NHibernate;

namespace Bill.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityUuidString
    {
        protected readonly ISession Session;

        public Repository(IUnitOfWork unitOfWork)
        {
            Session = ((UnitOfWork)unitOfWork).Session;
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
        /// <returns></returns>
        /// <summary>
        ///     新增数据
        /// </summary>
        /// <param name="entity"></param>
        public int Add(T entity)
        {
            if (entity == null)
                return -1;
            return (int) Session.Save(entity);
        }

        /// <summary>
        ///     更新数据
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (entity == null)
                return;
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
            Session.Flush();
        }

        void IRepository<T>.Add(T entity)
        {
            Session.Save(entity);
        }

        #endregion
    }
}