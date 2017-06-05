using System;
using System.Collections.Generic;
using Bill.Domain;

namespace Bill.Repository
{
    public class Repository<T> where T : EntityInt32
    {
        protected readonly ISessionProvider SessionProvider;

        public Repository(ISessionProvider sessionProvider)
        {
            SessionProvider = sessionProvider;
        }

        #region IRepository<T> 成员

        /// <summary>
        ///     获得所有数据
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll()
        {
            var session = SessionProvider.GetCurrentSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var results = session.QueryOver<T>().List<T>();
                    tx.Commit();
                    return results;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
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
            var session = SessionProvider.GetCurrentSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var id = (int) session.Save(entity);
                    tx.Commit();
                    return id;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///     更新数据
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (entity == null)
                return;
            var session = SessionProvider.GetCurrentSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///     删除数据
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            if (entity == null)
                return;
            var session = SessionProvider.GetCurrentSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.Delete(entity);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///     批量添加数据
        /// </summary>
        /// <param name="entities"></param>
        public void BatchAdd(IEnumerable<T> entities)
        {
            var session = SessionProvider.GetCurrentStatelessSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    foreach (var t in entities)
                        session.Insert(t);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///     批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        public void BatchUpdate(IEnumerable<T> entities)
        {
            var session = SessionProvider.GetCurrentStatelessSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    foreach (var t in entities)
                        session.Update(t);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///     批量删除数据
        /// </summary>
        /// <param name="entities"></param>
        public void BatchDelete(IEnumerable<T> entities)
        {
            var session = SessionProvider.GetCurrentStatelessSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    foreach (var t in entities)
                        session.Delete(t);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///     根据实体状态自动判断删除还是更新
        /// </summary>
        /// <param name="entity"></param>
        public void SaveOrUpdate(T entity)
        {
            var session = SessionProvider.GetCurrentSession();
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        ///     提交数据到数据库
        /// </summary>
        public void Flush()
        {
            var session = SessionProvider.GetCurrentSession();
            session.Flush();
        }

        #endregion
    }
}