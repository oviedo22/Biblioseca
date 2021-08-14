using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioseca.Model;
using NHibernate;
using NHibernate.Cfg;

namespace Biblioseca.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            ISessionFactory isessionFactory = new Configuration()
                .Configure()
                .BuildSessionFactory();

            ISession session = isessionFactory.OpenSession();

            Author author = session.Get<Author>(1);
            Category category = session.Get<Category>(1);
            Book book = session.Get<Book>(1);

            Lending lending = new Lending();


            //Console.WriteLine(book.Category.Name);


   
            Console.ReadKey();

        }
    }
}
