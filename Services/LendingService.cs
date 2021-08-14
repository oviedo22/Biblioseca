using System;
using System.Collections.Generic;
using System.Linq;
using Biblioseca.DataAccess.Books;
using Biblioseca.DataAccess.Lendings;
using Biblioseca.DataAccess.Members;
using Biblioseca.Model;
using Biblioseca.Model.Exception;

namespace Biblioseca.Service
{
    public class LendingService
    {
        private readonly LendingDao lendingDao;
        private readonly BookDao bookDao;
        private readonly MemberDao memberDao;

        public LendingService(LendingDao lendingDao, BookDao bookDao, MemberDao memberDao)
        {
            this.lendingDao = lendingDao;
            this.bookDao = bookDao;
            this.memberDao = memberDao;
        }

        public Lending LendingABook(int bookId, int memberId)
        {
            Ensure.IsTrue(bookId > 0, "Book.Id debe ser mayor que 0. ");
            Book book = bookDao.Get(bookId);
            Ensure.NotNull(book, "Libro no existe. ");
            Ensure.IsTrue(book.Stock > 0, "No hay stock disponible. ");

            Ensure.IsTrue(bookId > 0, "Book.Id debe ser mayor que 0. ");
            Member member = memberDao.Get(memberId);
            Ensure.NotNull(member, "Socio no existe. ");

            IEnumerable<Lending> lendings = lendingDao.GetLendings(bookId, memberId);

            Ensure.IsTrue(lendings.Count() < 2, "El socio no puede pedir prestado más libros. ");

            Lending lending = Lending
                 .Create(book, member);


            book.DecreaseStock();
            lendingDao.Save(lending);

            return lending;
        }

        public bool Returns(int bookId, int memberId)
        {
            Ensure.IsTrue(bookId > 0, "Book.Id debe ser mayor que 0. ");
            Book book = bookDao.Get(bookId);
            Ensure.NotNull(book, "Libro no existe. ");

            Ensure.IsTrue(memberId > 0, "Member.Id debe ser mayor que 0. ");
            Member member = memberDao.Get(memberId);
            Ensure.NotNull(member, "Socio no existe. ");

            Lending lending = lendingDao.GetLending(bookId, memberId);
            Ensure.NotNull(lending, "No existe prestamo del libro para el socio. ");

            lending.Returned();
            book.IncreaseStock();

            lendingDao.Save(lending);

            return true;
        }
    }
}