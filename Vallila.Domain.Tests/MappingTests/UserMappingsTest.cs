using System;
using Vallila.Domain;
using NHibernate;
using NHibernate.Driver;
using NUnit.Framework;

namespace Vallila.Domain.Tests.MappingTests
{
    [TestFixture]
    public class UserMappingsTest : MappingsTestBase
    {
        [Test]
        public void UserMapsPrimitiveProperties()
        {
            object id = 0;
            using (var transaction = session.BeginTransaction())
            {
                id = session.Save(new User
                {
                    Name = "TestUser",
                    Abbreviation = "TestU"
                });
                transaction.Commit();
            }

            session.Clear();

            using (var transaction = session.BeginTransaction())
            {
                var user = session.Get<User>(id);
                Assert.That(user.Name, Is.EqualTo("TestUser"));
                Assert.That(user.Abbreviation, Is.EqualTo("TestU"));
                transaction.Commit();
            }
        }
    }
}
