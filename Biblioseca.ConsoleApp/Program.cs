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

            Author author = new Author();

            author.FirstName = "Ernesto";
            author.LastName = "Sábato";

            Author author2 = new Author();
            author2.FirstName = "Ernesto";
            author2.LastName = "Lapadula";

            Author author3 = new Author();
            author3.FirstName = "Borges";
            author3.LastName = "Borges";

            session.Save(author3);
            Console.WriteLine(author3.Id);
            Console.ReadKey();

        }
    }
}
