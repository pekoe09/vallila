using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class ActivityMappingsTest : MappingsTestBase
    {
        [Test]
        public void ActivityMapsPrimitiveProperties()
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

        [Test]
        public void ActivityMapsRelations()
        {
            object masterId = 0;
            using (var transaction = session.BeginTransaction())
            {
                masterId = session.Save(new Activity
                {
                    Name = "MasterActivity",
                    Abbreviation = "Master",
                    MasterActivity = null
                });
                transaction.Commit();
            }

            session.Clear();
            Activity masterActivity = session.Get<Activity>(masterId);

            object subId = 0;
            using (var transaction = session.BeginTransaction())
            {
                subId = session.Save(new Activity
                {
                    Name = "SubActivity",
                    Abbreviation = "Sub",
                    MasterActivity = masterActivity
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var activity = session.Get<Activity>(subId);
                Assert.That(activity.Name, Is.EqualTo("SubActivity"));
                Assert.That(activity.MasterActivity, Is.Not.Null);
                Assert.That(activity.MasterActivity.Id, Is.EqualTo(masterId));
                Assert.That(activity.MasterActivity.Name, Is.EqualTo("MasterActivity"));
                transaction.Commit();
            }
        }
    }
}
