using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class ProjectMappingsTest : MappingsTestBase
    {
        [Test]
        public void ProjectMapsPrimitiveProperties()
        {
            object id = 0;
            DateTime startDate = new DateTime(2016, 10, 9);
            DateTime endDate = new DateTime(2017, 3, 31);
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new Project
                {
                    Name = "TestProject",
                    StartDate = startDate,
                    EndDate = endDate
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var project = session.Get<Project>(id);
                Assert.That(project.Name, Is.EqualTo("TestProject"));
                Assert.That(project.StartDate, Is.EqualTo(startDate));
                Assert.That(project.EndDate, Is.EqualTo(endDate));
            }
        }
    }
}
