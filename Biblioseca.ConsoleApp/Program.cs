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
            Book book = new Book();

            book.Title = "Operación Masacre";
            book.AuthorId = 4;
            book.Description = "Trata sobre una operación que terminó en Masacre";
            book.Category = "Novela No Ficción";
            book.ISBN = "978-950-515-352-7";

            session.Save(book);
            Console.ReadKey();

        }
    }
}
