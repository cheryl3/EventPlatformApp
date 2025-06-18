using EventPlatformApp.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace EventPlatformApp.Helpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory CreateSessionFactory(string dbFilePath)
        {
            if (_sessionFactory != null)
                return _sessionFactory;

            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                .UsingFile(dbFilePath))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EventMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TicketMap>())
                .BuildSessionFactory();

            return _sessionFactory;
        }
    }
}
