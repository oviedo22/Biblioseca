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
    public class BookTest
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
        public void CreateBook()
        {
            Author author = session.Get<Author>(1);
            Category category = session.Get<Category>(1);

            Book book = new Book
            {

                Title="El silencio de los inocentes",
                Author= author,
                Description="Description",
                Category= category,
                ISBN="43342243",
                Price=35

            };

            session.Save(book);
            session.Flush();
            session.Clear();

            Assert.IsTrue(book.Id > 0);

            Book created = this.session.Get<Book>(book.Id);

            Assert.AreEqual(book.Id, created.Id);

        }
    }
}
