using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class NationalHolidayMappingsTest : MappingsTestBase
    {
        [Test]
        public void NationalHolidayMapsPrimitiveProperties()
        {
            object id = 0;
            DateTime dt = new DateTime(2017, 6, 1);
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new NationalHoliday
                {
                    Name = "TestHoliday",
                    Date = dt,
                    Description = "TestDescription"
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var holiday = session.Get<NationalHoliday>(id);
                Assert.That(holiday.Name, Is.EqualTo("TestHoliday"));
                Assert.That(holiday.Date, Is.EqualTo(dt));
                Assert.That(holiday.Description, Is.EqualTo("TestDescription"));
                transaction.Commit();
            }
        }
    }
}
