using Biblioseca.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioseca.Test
{
    [TestClass]
    public class MemberTest
    {
        private ISessionFactory sessionFactory;
        private ISession session;
        private ITransaction transaction;


        [TestInitialize]
        public void SetUp()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
            session = sessionFactory.OpenSession();
            transaction = session.BeginTransaction();
        }

        [TestCleanup]
        public void CleanUp()
        {
            transaction.Rollback();
            session.Close();
        }

        [TestMethod]
        public void CreateMember()
        {

            Member member = new Member
            {
                FirstName = "Wanda",
                LastName = "Maximoff",
                Username = "WandaMaxi96",
                Lendings= lendings
            };

            session.Save(member);
            session.Flush();
            session.Clear();

            Assert.IsTrue(member.Id > 0);

            Member created = this.session.Get<Member>(member.Id);

            Assert.AreEqual(member.Id, created.Id);

        }
    }
}
