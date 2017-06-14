using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests
{
    [TestFixture]
    public class ActivityMappingsTest
    {
        private InMemoryDatabaseForXmlMappings database;
        private ISession session;

        [TestFixtureSetUp]
        public void Setup()
        {
            database = new InMemoryDatabaseForXmlMappings();
            session = database.Session;
        }

        [Test]
        public void MapsPrimitiveProperties()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new Activity
                {
                    Name = "TestActivity",
                    Abbreviation = "TestAct",
                    MasterActivity = null
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var activity = session.Get<Activity>(id);
                Assert.That(activity.Name, Is.EqualTo("TestActivity"));
                Assert.That(activity.Abbreviation, Is.EqualTo("TestAct"));
                Assert.That(activity.MasterActivity, Is.Null);
                transaction.Commit();
            }
        }
    }
}
