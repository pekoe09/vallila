using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class LoggedTimeMappingsTest : MappingsTestBase
    {
        [Test]
        public void LoggedTimeMapsAllProperties()
        {
            object userId = 0;
            object activityId = 0;
            object customerId = 0;
            object projectId = 0;
            DateTime startTime = new DateTime(2016, 10, 30, 9, 30, 10);
            DateTime endTime = new DateTime(2016, 10, 30, 18, 59, 59);
            using (var transaction = session.BeginTransaction())
            {
                userId = session.Save(new User
                {
                    Name = "TestUser"
                });
                activityId = session.Save(new Activity
                {
                    Name = "TestActivity"
                });
                customerId = session.Save(new Customer
                {
                    Name = "TestCustomer"
                });
                projectId = session.Save(new Project
                {
                    Name = "TestProject",
                    StartDate = startTime,
                    EndDate = endTime
                });
                transaction.Commit();
            }
            session.Clear();

            User user = session.Get<User>(userId);
            Activity activity = session.Get<Activity>(activityId);
            Customer customer = session.Get<Customer>(customerId);
            Project project = session.Get<Project>(projectId);
            

            object timeId = 0;
            using(var transaction = session.BeginTransaction())
            {
                timeId = session.Save(new LoggedTime
                {
                    User = user,
                    Activity = activity,
                    Customer = customer,
                    Project = project,
                    StartTime = startTime,
                    EndTime = endTime,
                    Description = "TestDescription"
                });
                transaction.Commit();
            }

            session.Clear();

            using(var transaction = session.BeginTransaction())
            {
                var loggedTime = session.Get<LoggedTime>(timeId);
                Assert.That(loggedTime.Description, Is.EqualTo("TestDescription"));
                Assert.That(loggedTime.StartTime, Is.EqualTo(startTime));
                Assert.That(loggedTime.EndTime, Is.EqualTo(endTime));
                Assert.That(loggedTime.User, Is.Not.Null);
                Assert.That(loggedTime.User.Name, Is.EqualTo("TestUser"));
                Assert.That(loggedTime.Activity, Is.Not.Null);
                Assert.That(loggedTime.Activity.Name, Is.EqualTo("TestActivity"));
                Assert.That(loggedTime.Customer, Is.Not.Null);
                Assert.That(loggedTime.Customer.Name, Is.EqualTo("TestCustomer"));
                Assert.That(loggedTime.Project, Is.Not.Null);
                Assert.That(loggedTime.Project.Name, Is.EqualTo("TestProject"));
                transaction.Commit();
            }
        }
    }
}
