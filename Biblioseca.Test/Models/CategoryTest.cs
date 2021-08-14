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
    public class CategoryTest
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
        public void CreateCategory()
        {

            Category category = new Category
            {
                Name = "Policial"
            };

            session.Save(category);
            session.Flush();
            session.Clear();

            Assert.IsTrue(category.Id > 0);

            Category created = this.session.Get<Category>(category.Id);

            Assert.AreEqual(category.Id, created.Id);

        }

    }
}
