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
    public class LendingTest
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
        public void CreateLending()
        {
            Book book = session.Get<Book>(1);
            Member member = session.Get<Member>(1);
          

            Lending lending = new Lending
            {
               Book=book, 
               Member=member,
               LendDate= new DateTime(),
               ReturnDate= new DateTime()

            };

            session.Save(lending);
            session.Flush();
            session.Clear();

            Assert.IsTrue(lending.Id > 0);

            Lending created = this.session.Get<Lending>(lending.Id);

            Assert.AreEqual(lending.Id, created.Id);

        }

    }
}
