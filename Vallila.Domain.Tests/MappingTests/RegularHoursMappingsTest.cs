using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class RegularHoursMappingsTest : MappingsTestBase
    {
        [Test]
        public void RegularHoursMapsPrimitiveProperties()
        {
            object id = 0;
            DateTime startTime = new DateTime(1950, 1, 1, 9, 0, 0);
            DateTime endTime = new DateTime(1950, 1, 1, 17, 45, 0);
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new RegularHours
                {
                    WeekDay = WeekDay.Wednesday,
                    StartTime = startTime,
                    EndTime = endTime
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var hours = session.Get<RegularHours>(id);
                Assert.That(hours.WeekDay, Is.EqualTo(WeekDay.Wednesday));
                Assert.That(hours.StartTime, Is.EqualTo(startTime));
                Assert.That(hours.EndTime, Is.EqualTo(endTime));
                transaction.Commit();
            }
        }
    }
}
