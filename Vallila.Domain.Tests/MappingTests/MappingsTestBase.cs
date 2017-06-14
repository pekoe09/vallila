using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{    
    public abstract class MappingsTestBase
    {
        protected InMemoryDatabaseForXmlMappings database;
        protected ISession session;

        [OneTimeSetUp]
        public void Setup()
        {
            database = new InMemoryDatabaseForXmlMappings();
            session = database.Session;
        }
    }
}
