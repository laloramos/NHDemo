using NHibernate;
using StructureMap.Configuration.DSL;
using StructureMap.Web;

namespace NHibernateSample.Database
{
    public class NhibernateRegistry : Registry
    {
        public NhibernateRegistry()
        {
            For<ISessionFactory>().Singleton().Use(new ConfigurationFactory().CreateConfiguration().BuildSessionFactory());
            For<ISession>().HybridHttpOrThreadLocalScoped().Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}