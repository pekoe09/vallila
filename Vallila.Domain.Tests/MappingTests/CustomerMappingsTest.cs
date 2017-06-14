using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class CustomerMappingsTest : MappingsTestBase
    {
        [Test]
        public void CustomerMapsPrimitiveProperties()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new Customer
                {
                    Name = "TestCustomer",
                    OfficialId = "1234",
                    ContactPerson = "TestPerson",
                    EMail = "TestEmail",
                    Phone = "1234",
                    ShippingAddress = null,
                    BillingAddress = null
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var customer = session.Get<Customer>(id);
                Assert.That(customer.Name, Is.EqualTo("TestCustomer"));
                Assert.That(customer.OfficialId, Is.EqualTo("1234"));
                Assert.That(customer.ContactPerson, Is.EqualTo("TestPerson"));
                Assert.That(customer.EMail, Is.EqualTo("TestEmail"));
                Assert.That(customer.Phone, Is.EqualTo("1234"));
                Assert.That(customer.ShippingAddress, Is.Null);
                Assert.That(customer.BillingAddress, Is.Null);
            }
        }

        [Test]
        public void CustomerMapsRelations()
        {
            object shippingId = 0;
            using (var transaction = session.BeginTransaction())
            {
                shippingId = session.Save(new Address
                {
                    Street1 = "Ship1",
                    Zip = "ShipZip",
                    City = "ShipCity",
                    Country = "ShipCountry"
                });
                transaction.Commit();
            }

            session.Clear();

            object billingId = 0;
            using (var transaction = session.BeginTransaction())
            {
                billingId = session.Save(new Address
                {
                    Street1 = "Bill1",
                    Zip = "BillZip",
                    City = "BillCity",
                    Country = "BillCountry"
                });
                transaction.Commit();
            }

            session.Clear();

            Address shipping = session.Get<Address>(shippingId);
            Address billing = session.Get<Address>(billingId);

            object custId = 0;
            using (var transaction = session.BeginTransaction())
            {
                custId = session.Save(new Customer
                {
                    Name = "TestCustomer",
                    ContactPerson = "TestContact",
                    OfficialId = "1234",
                    EMail = "TestEmail",
                    Phone = "TestPhone",
                    BillingAddress = billing,
                    ShippingAddress = shipping
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var customer = session.Get<Customer>(custId);
                Assert.That(customer.Name, Is.EqualTo("TestCustomer"));
                Assert.That(customer.ShippingAddress, Is.Not.Null);
                Assert.That(customer.ShippingAddress.Id, Is.EqualTo(shippingId));
                Assert.That(customer.ShippingAddress.Street1, Is.EqualTo("Ship1"));
                Assert.That(customer.BillingAddress, Is.Not.Null);
                Assert.That(customer.BillingAddress.Id, Is.EqualTo(billingId));
                Assert.That(customer.BillingAddress.Street1, Is.EqualTo("Bill1"));
                transaction.Commit();
            }
        }
    }
}
