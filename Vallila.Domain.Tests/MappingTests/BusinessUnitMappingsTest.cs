using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    public class BusinessUnitMappingsTest : MappingsTestBase
    {
        [Test]
        public void BusinessUnitMapsPrimitiveProperties()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new BusinessUnit
                {
                    Name = "TestBusinessUnit",
                    ShortName = "TestUnit",
                    Abbreviation = "TBU",
                    ExternalId = "1234"
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var businessUnit = session.Get<BusinessUnit>(id);
                Assert.That(businessUnit.Name, Is.EqualTo("TestBusinessUnit"));
                Assert.That(businessUnit.ShortName, Is.EqualTo("TestUnit"));
                Assert.That(businessUnit.Abbreviation, Is.EqualTo("TBU"));
                Assert.That(businessUnit.ExternalId, Is.EqualTo("1234"));
            }
        }
    }
}
