using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class CustomerProjectShareMappingsTest : MappingsTestBase
    {
        [Test]
        public void CustomerProjectShareMapsPrimitiveProperties()
        {
            object customerId = 0;
            object projectId = 0;
            using (var transaction = session.BeginTransaction())
            {
                customerId = session.Save(new Customer
                {
                    Name = "TestCustomer"
                });
                projectId = session.Save(new Project
                {
                    Name = "TestProject",
                    StartDate = new DateTime(1950, 1, 1),
                    EndDate = new DateTime(1950, 1, 2)
                });
                transaction.Commit();
            }

            session.Clear();

            Customer customer = session.Get<Customer>(customerId);
            Project project = session.Get<Project>(projectId);

            object cpsId = 0;
            using(var transaction = session.BeginTransaction())
            {
                cpsId = session.Save(new CustomerProjectShare
                {
                    Customer = customer,
                    Project = project,
                    Share = 0.37
                });
                transaction.Commit();
            }

            session.Clear();

            using(var transaction = session.BeginTransaction())
            {
                var cps = session.Get<CustomerProjectShare>(cpsId);
                Assert.That(cps.Customer, Is.Not.Null);
                Assert.That(cps.Customer.Name, Is.EqualTo("TestCustomer"));
                Assert.That(cps.Project, Is.Not.Null);
                Assert.That(cps.Project.Name, Is.EqualTo("TestProject"));
                transaction.Commit();
            }
        }

    }
}
