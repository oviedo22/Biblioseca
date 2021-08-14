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
    public class AuthorTest
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
        public void CreateAuthor()
        {

            Author author = new Author
            {
                FirstName = "Wanda",
                LastName = "Maximoff"
            };

            session.Save(author);
            session.Flush();
            session.Clear();

            Assert.IsTrue(author.Id > 0);

            Author created = this.session.Get<Author>(author.Id);

            Assert.AreEqual(author.Id, created.Id);

        }
    }
}
