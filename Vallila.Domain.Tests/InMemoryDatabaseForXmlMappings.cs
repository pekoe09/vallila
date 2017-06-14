using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Environment = NHibernate.Cfg.Environment;

namespace Vallila.Domain.Tests
{
    public class InMemoryDatabaseForXmlMappings : IDisposable
    {
        protected Configuration config;
        protected ISessionFactory sessionFactory;

        public InMemoryDatabaseForXmlMappings()
        {
            config = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(MsSql2012Dialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SqlClientDriver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, @"data source=.\SQLEXPRESS;database=vallilatst;integrated security=true")
                .AddFile(@"C:\Koodausprojektit\vallila\Vallila.Persistence\Mappings\Xml\Activity.hbm.xml")
                .AddFile(@"C:\Koodausprojektit\vallila\Vallila.Persistence\Mappings\Xml\Address.hbm.xml")
                .AddFile(@"C:\Koodausprojektit\vallila\Vallila.Persistence\Mappings\Xml\BusinessUnit.hbm.xml")
                .AddFile(@"C:\Koodausprojektit\vallila\Vallila.Persistence\Mappings\Xml\Customer.hbm.xml")
                .AddFile(@"C:\Koodausprojektit\vallila\Vallila.Persistence\Mappings\Xml\NationalHoliday.hbm.xml");
            sessionFactory = config.BuildSessionFactory();
            Session = sessionFactory.OpenSession();
            new SchemaExport(config).Execute(true, true, false, Session.Connection, Console.Out);
        }

        public ISession Session { get; set; }

        public void Dispose()
        {
            Session.Dispose();
            sessionFactory.Dispose();
        }
    }
}
