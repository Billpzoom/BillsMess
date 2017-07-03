using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Bill.Application;
using Bill.IRepository;
using Bill.Repository;
using NHibernate;
using NHibernate.Cfg;

namespace Bill.WebApi
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var nhConfig = new Configuration().Configure(HttpContext.Current.Server.MapPath("/hibernate.cfg.xml"));
            var builder = new ContainerBuilder();
            SetupResolveRules(builder, nhConfig);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }

        private static void SetupResolveRules(ContainerBuilder builder, Configuration nhConfig)
        {
            builder.Register(c => new UserService(c.Resolve<IUserRepository>(), c.Resolve<IUnitOfWork>()));
            builder.Register(c => new UserRepository(c.Resolve<IUnitOfWork>())).As<IUserRepository>();



            builder.Register(c => new UnitOfWork(c.Resolve<ISessionProvider>())).As<IUnitOfWork>().InstancePerRequest();
            builder.Register(c => new SessionProvider(c.Resolve<ISessionFactory>())).As<ISessionProvider>();
            builder.Register(c => nhConfig.BuildSessionFactory());
            WebApiApplication.BaseContainer = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(WebApiApplication.BaseContainer));
        }

        public static TService Resolve<TService>()
        {
            return WebApiApplication.BaseContainer.Resolve<TService>();
        }
    }
}