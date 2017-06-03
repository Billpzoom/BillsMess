using NHibernate;

namespace Bill.DataAccess
{
    public class SessionProvider
    {
        private static IStatelessSession _currentStatelessSession;
        private readonly ISessionFactory _sessionFactory;
        private ISession _currentSession;

        public SessionProvider(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        #region IDisposable 成员

        /// <summary>
        ///     资源释放
        /// </summary>
        public void Dispose()
        {
            _currentSession?.Dispose();
            _currentStatelessSession?.Dispose();
            _currentSession = null;
            _currentStatelessSession = null;
        }

        #endregion

        #region ISessionProvider 成员

        /// <summary>
        ///     获得当前的Session对象
        /// </summary>
        /// <returns></returns>
        public ISession GetCurrentSession()
        {
            if (_currentSession == null || _currentSession.IsOpen == false)
                _currentSession = _sessionFactory.OpenSession();
            return _currentSession;
        }

        /// <summary>
        ///     获得当前的StatelessSession对象
        /// </summary>
        /// <returns></returns>
        public IStatelessSession GetCurrentStatelessSession()
        {
            if (_currentStatelessSession == null || _currentStatelessSession.IsOpen == false)
                _currentStatelessSession = _sessionFactory.OpenStatelessSession();
            return _currentStatelessSession;
        }

        /// <summary>
        ///     释放Session
        /// </summary>
        public void DisposeCurrentSession()
        {
            _currentSession.Dispose();
        }

        /// <summary>
        ///     释放StatelessSession
        /// </summary>
        public void DisposeCurrentStatelessSession()
        {
            _currentStatelessSession.Dispose();
        }

        #endregion
    }
}