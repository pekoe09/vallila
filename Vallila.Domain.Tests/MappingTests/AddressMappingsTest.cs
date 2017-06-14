using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class AddressMappingsTest : MappingsTestBase
    {
        [Test]
        public void AddressMapsPrimitiveProperties()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new Address
                {
                    Street1 = "TestStreet1",
                    Street2 = "TestStreet2",
                    Zip = "000",
                    City = "TestCity",
                    Country = "TestCountry"
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var address = session.Get<Address>(id);
                Assert.That(address.Street1, Is.EqualTo("TestStreet1"));
                Assert.That(address.Street2, Is.EqualTo("TestStreet2"));
                Assert.That(address.Zip, Is.EqualTo("000"));
                Assert.That(address.City, Is.EqualTo("TestCity"));
                Assert.That(address.Country, Is.EqualTo("TestCountry"));
                transaction.Commit();
            }
        }
    }
}
